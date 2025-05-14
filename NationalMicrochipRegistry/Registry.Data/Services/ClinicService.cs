using System.Collections.Generic;
using System.Linq;
using Registry.Data.Models;

namespace Registry.Data.Services
{
    /// <summary>
    /// Provides services related to clinic management.
    /// </summary>
    public class ClinicService
    {
        private readonly RegistryDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClinicService"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public ClinicService(RegistryDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new clinic to the database.
        /// </summary>
        /// <param name="clinic">The clinic to add.</param>
        public void AddClinic(Clinic clinic)
        {
            _context.Clinics.Add(clinic);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes a clinic by ID.
        /// </summary>
        /// <param name="clinicId">The ID of the clinic to delete.</param>
        public void DeleteClinic(int clinicId)
        {
            var clinic = _context.Clinics.Find(clinicId);
            if (clinic != null)
            {
                _context.Clinics.Remove(clinic);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Retrieves all clinics from the database.
        /// </summary>
        /// <returns>A list of clinics.</returns>
        public List<Clinic> GetAllClinics() => _context.Clinics.ToList();
    }
}
