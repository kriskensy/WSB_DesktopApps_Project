﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVVMFirma.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Diving4LifeEntities : DbContext
    {
        public Diving4LifeEntities()
            : base("name=Diving4LifeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BuddySystem> BuddySystem { get; set; }
        public virtual DbSet<Certificates> Certificates { get; set; }
        public virtual DbSet<CertificationOrganization> CertificationOrganization { get; set; }
        public virtual DbSet<DiveConditions> DiveConditions { get; set; }
        public virtual DbSet<DiveLogs> DiveLogs { get; set; }
        public virtual DbSet<DiveSites> DiveSites { get; set; }
        public virtual DbSet<DiveStatistic> DiveStatistic { get; set; }
        public virtual DbSet<DiveTypes> DiveTypes { get; set; }
        public virtual DbSet<EmergencyContacts> EmergencyContacts { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<EquipmentCategories> EquipmentCategories { get; set; }
        public virtual DbSet<EquipmentManufacturer> EquipmentManufacturer { get; set; }
        public virtual DbSet<MaintenanceSchedule> MaintenanceSchedule { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TypeOfTraining> TypeOfTraining { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}