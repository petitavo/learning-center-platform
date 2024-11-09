using ACME.LearningCenterPlatform.API.CRM.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Discipline.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Discipline.Domain.Model.Entities;
using ACME.LearningCenterPlatform.API.Hr.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Kr.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using ACME.LearningCenterPlatform.API.SoccerPlayer.Domain.Model.Entities;
using ACME.LearningCenterPlatform.API.Subscriptions.Domain.Model.Aggregate;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
///     Application database context for the Learning Center Platform
/// </summary>
/// <param name="options">
///     The options for the database context
/// </param>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
   /// <summary>
   ///     On configuring the database context
   /// </summary>
   /// <remarks>
   ///     This method is used to configure the database context.
   ///     It also adds the created and updated date interceptor to the database context.
   /// </remarks>
   /// <param name="builder">
   ///     The options builder for the database context
   /// </param>
   protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

   /// <summary>
   ///     On creating the database model
   /// </summary>
   /// <remarks>
   ///     This method is used to create the database model for the application.
   /// </remarks>
   /// <param name="builder">
   ///     The model builder for the database context
   /// </param>
   protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        builder.Entity<City>().ToTable("Cities");
        builder.Entity<City>().HasKey(c => c.Id);
        builder.Entity<City>().Property(c => c.Name).IsRequired().HasMaxLength(50);

        builder.Entity<City>().HasData(
            new City { Id = 1, Name = "Buenos Aires" },
            new City { Id = 2, Name = "São Paulo" },
            new City { Id = 3, Name = "Berlín" },
            new City { Id = 4, Name = "Madrid" }
        );


        builder.Entity<SoccerPlayer.Domain.Model.Aggregate.SoccerPlayer>().ToTable("SoccerPlayers");
        builder.Entity<SoccerPlayer.Domain.Model.Aggregate.SoccerPlayer>().HasKey(sp => sp.Id);
        builder.Entity<SoccerPlayer.Domain.Model.Aggregate.SoccerPlayer>().Property(sp => sp.Id).IsRequired()
            .ValueGeneratedOnAdd();
        builder.Entity<SoccerPlayer.Domain.Model.Aggregate.SoccerPlayer>().Property(sp => sp.Name).IsRequired()
            .HasMaxLength(50);
        builder.Entity<SoccerPlayer.Domain.Model.Aggregate.SoccerPlayer>().Property(sp => sp.Country).IsRequired();
        builder.Entity<SoccerPlayer.Domain.Model.Aggregate.SoccerPlayer>().Property(sp => sp.Position).IsRequired()
            .HasMaxLength(100);
        builder.Entity<SoccerPlayer.Domain.Model.Aggregate.SoccerPlayer>().Property(sp => sp.BirthDate).IsRequired();
        builder.Entity<SoccerPlayer.Domain.Model.Aggregate.SoccerPlayer>()
            .HasOne<City>()
            .WithMany()
            .HasForeignKey(sp => sp.Country);
        //discipline context


        builder.Entity<Sport>().ToTable("Sport");
        builder.Entity<Sport>().HasKey(s => s.Id);
        builder.Entity<Sport>().Property(s => s.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Sport>().HasData(
            new Sport { Id = "1", Name = "basket" },
            new Sport { Id = "2", Name = "futbol" },
            new Sport { Id = "3", Name = "vollet" },
            new Sport { Id = "4", Name = "golf" }
        );

        builder.Entity<AthleticDiscipline>().ToTable("AthleticDiscipline");
        builder.Entity<AthleticDiscipline>().HasKey(ad => ad.Id);
        builder.Entity<AthleticDiscipline>().Property(ad => ad.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<AthleticDiscipline>().Property(ad => ad.Name).IsRequired().HasMaxLength(50);
        builder.Entity<AthleticDiscipline>().Property(ad => ad.SportId).IsRequired().HasMaxLength(50);
        builder.Entity<AthleticDiscipline>().Property(ad => ad.Mode).HasMaxLength(100);
        builder.Entity<AthleticDiscipline>()
            .HasOne<Sport>()
            .WithMany()
            .HasForeignKey(ad => ad.SportId);

        
        // Hr context
        
        builder.Entity<Appointments>().ToTable("Appointments");
        builder.Entity<Appointments>().HasKey(a => a.Id);
        builder.Entity<Appointments>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Appointments>().Property(a => a.DoctorName).IsRequired().HasMaxLength(50);
        builder.Entity<Appointments>().Property(a => a.PatientName).IsRequired().HasMaxLength(50);
        builder.Entity<Appointments>().Property(a => a.Email).IsRequired().HasMaxLength(50);
        builder.Entity<Appointments>().Property(a => a.Specialty).IsRequired();
        builder.Entity<Appointments>().Property(a => a.Date).IsRequired();
        builder.Entity<Appointments>().Property(a => a.Time).IsRequired();
        // Plan context

        builder.Entity<Plan>().ToTable("Plans");
        builder.Entity<Plan>().HasKey(p => p.Id);
        builder.Entity<Plan>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Plan>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Plan>().Property(p => p.MaxUsers).IsRequired();
        builder.Entity<Plan>().Property(p => p.IsDefault).IsRequired();
        builder.Entity<Plan>().Property(p => p.MonetizationStrategyId).IsRequired();
        
        // King Rental
        
        builder.Entity<Kingrentals>().ToTable("Kingrentals");
        builder.Entity<Kingrentals>().HasKey(k => k.Id);
        builder.Entity<Kingrentals>().Property(k => k.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Kingrentals>().Property(k => k.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Kingrentals>().Property(k => k.DepartmentId).IsRequired();
        builder.Entity<Kingrentals>().Property(k => k.ResumeUrl).IsRequired();
        builder.Entity<Kingrentals>().Property(k => k.DesiredJobTitle).IsRequired();
        
//id (int, 
        //   obligatorio, autogenerado, llave primaria), VeterinaryCampaignManagerId(string, obligatorio, 
        //   autogenerado, Guid único), firstName (string, obligatorio, entre 4 y 40 caracteres), lastName 
        //   (string, obligatorio, entre 4 y 40 caracteres), status (int, obligatorio, restringido por 
        //EManagerStatus), assignedSalesAgentId (int, no obligatorio), contactedAt (Date, no 
        //obligatorio), approvedAt (Date, no obligatorio), reportedAt (Date, no obligatorio) . 
      
        builder.Entity<Manager>().HasKey(a => a.Id);
        builder.Entity<Manager>().Property(a => a.Id).ValueGeneratedOnAdd();
      
        builder.Entity<Manager>().Property(a => a.VeterinaryCampaignManagerId).IsRequired().HasMaxLength(120);
        builder.Entity<Manager>().Property(a => a.FirstName).IsRequired().HasMaxLength(40);
        builder.Entity<Manager>().Property(a => a.LastName).IsRequired().HasMaxLength(40);
        builder.Entity<Manager>().Property(a => a.Status).IsRequired();
        builder.Entity<Manager>().Property(a => a.AssignedSalesAgentId);
        builder.Entity<Manager>().Property(a => a.ContactedAt);
        builder.Entity<Manager>().Property(a => a.ApprovedAt);
        builder.Entity<Manager>().Property(a => a.ReportedAt);

        // Publishing Context
        builder.Entity<Category>().HasKey(c => c.Id);
        builder.Entity<Category>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(30);

        builder.Entity<Tutorial>().HasKey(t => t.Id);
        builder.Entity<Tutorial>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Tutorial>().Property(t => t.Title).IsRequired().HasMaxLength(50);
        builder.Entity<Tutorial>().Property(t => t.Summary).IsRequired().HasMaxLength(240);

        builder.Entity<Asset>().HasDiscriminator(a => a.Type);
        builder.Entity<Asset>().HasKey(a => a.Id);
        builder.Entity<Asset>().HasDiscriminator<string>("asset_type")
            .HasValue<Asset>("asset_base")
            .HasValue<ImageAsset>("asset_image")
            .HasValue<VideoAsset>("asset_video")
            .HasValue<ReadableContentAsset>("asset_readable_content");

        builder.Entity<Asset>().OwnsOne(i => i.AssetIdentifier, ai =>
        {
            ai.WithOwner().HasForeignKey("Id");
            ai.Property(p => p.Identifier).HasColumnName("AssetIdentifier");
        });
        builder.Entity<ImageAsset>().Property(p => p.ImageUri).IsRequired();
        builder.Entity<VideoAsset>().Property(p => p.VideoUri).IsRequired();

        builder.Entity<Tutorial>().HasMany(t => t.Assets);

        // Profiles Context


        builder.UseSnakeCaseNamingConvention();
    }
}