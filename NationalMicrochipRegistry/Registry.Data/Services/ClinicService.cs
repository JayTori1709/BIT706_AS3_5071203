using System.Collections.Generic;
using System.Linq;
using Registry.Data.Models;

namespace Registry.Data.Services
{
    public class ClinicService
    {
        private readonly RegistryDbContext _context;

        public ClinicService(RegistryDbContext context)
        {
            _context = context;
        }

        public void AddClinic(Clinic clinic)
        {
            _context.Clinics.Add(clinic);
            _context.SaveChanges();
        }

        public void DeleteClinic(int clinicId)
        {
            var clinic = _context.Clinics.Find(clinicId);
            if (clinic != null)
            {
                _context.Clinics.Remove(clinic);
                _context.SaveChanges();
            }
        }

        public List<Clinic> GetAllClinics() => _context.Clinics.ToList();
    }
}