﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleIdServer.Scim.Persistence.EF;

namespace SimpleIdServer.Scim.SqlServer.Startup.Migrations
{
    [DbContext(typeof(SCIMDbContext))]
    partial class SCIMDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SCIMRepresentationSCIMSchema", b =>
                {
                    b.Property<string>("RepresentationsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SchemasId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RepresentationsId", "SchemasId");

                    b.HasIndex("SchemasId");

                    b.ToTable("SCIMRepresentationSCIMSchema");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domain.ProvisioningConfiguration", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ResourceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ProvisioningConfigurations");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domain.ProvisioningConfigurationHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Exception")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExecutionDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProvisioningConfigurationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProvisioningConfigurationId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RepresentationId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RepresentationVersion")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("WorkflowId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkflowInstanceId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProvisioningConfigurationId");

                    b.HasIndex("ProvisioningConfigurationId1");

                    b.ToTable("ProvisioningConfigurationHistory");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domain.ProvisioningConfigurationRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsArray")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProvisioningConfigurationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ProvisioningConfigurationRecordId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("ValuesString")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProvisioningConfigurationId");

                    b.HasIndex("ProvisioningConfigurationRecordId");

                    b.ToTable("ProvisioningConfigurationRecord");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domain.SCIMAttributeMapping", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SourceAttributeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceAttributeSelector")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceResourceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TargetAttributeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TargetResourceType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SCIMAttributeMappingLst");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domain.SCIMRepresentation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExternalId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResourceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SCIMRepresentationLst");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domain.SCIMRepresentationAttribute", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AttributeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentAttributeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RepresentationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SchemaAttributeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ValueBinary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("ValueBoolean")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ValueDateTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("ValueDecimal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ValueInteger")
                        .HasColumnType("int");

                    b.Property<string>("ValueReference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValueString")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RepresentationId");

                    b.HasIndex("SchemaAttributeId");

                    b.ToTable("SCIMRepresentationAttributeLst");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domain.SCIMSchema", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRootSchema")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResourceType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SCIMSchemaLst");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domain.SCIMSchemaAttribute", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CanonicalValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CaseExact")
                        .HasColumnType("bit");

                    b.Property<string>("DefaultValueInt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DefaultValueString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MultiValued")
                        .HasColumnType("bit");

                    b.Property<int>("Mutability")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferenceTypes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Required")
                        .HasColumnType("bit");

                    b.Property<int>("Returned")
                        .HasColumnType("int");

                    b.Property<string>("SchemaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("Uniqueness")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SchemaId");

                    b.ToTable("SCIMSchemaAttribute");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domain.SCIMSchemaExtension", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Required")
                        .HasColumnType("bit");

                    b.Property<string>("SCIMSchemaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Schema")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SCIMSchemaId");

                    b.ToTable("SCIMSchemaExtension");
                });

            modelBuilder.Entity("SCIMRepresentationSCIMSchema", b =>
                {
                    b.HasOne("SimpleIdServer.Scim.Domain.SCIMRepresentation", null)
                        .WithMany()
                        .HasForeignKey("RepresentationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimpleIdServer.Scim.Domain.SCIMSchema", null)
                        .WithMany()
                        .HasForeignKey("SchemasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domain.ProvisioningConfigurationHistory", b =>
                {
                    b.HasOne("SimpleIdServer.Scim.Domain.ProvisioningConfiguration", null)
                        .WithMany("HistoryLst")
                        .HasForeignKey("ProvisioningConfigurationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SimpleIdServer.Scim.Domain.ProvisioningConfiguration", "ProvisioningConfiguration")
                        .WithMany()
                        .HasForeignKey("ProvisioningConfigurationId1");

                    b.Navigation("ProvisioningConfiguration");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domain.ProvisioningConfigurationRecord", b =>
                {
                    b.HasOne("SimpleIdServer.Scim.Domain.ProvisioningConfiguration", null)
                        .WithMany("Records")
                        .HasForeignKey("ProvisioningConfigurationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SimpleIdServer.Scim.Domain.ProvisioningConfigurationRecord", null)
                        .WithMany("Values")
                        .HasForeignKey("ProvisioningConfigurationRecordId");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domain.SCIMRepresentationAttribute", b =>
                {
                    b.HasOne("SimpleIdServer.Scim.Domain.SCIMRepresentation", "Representation")
                        .WithMany("Attributes")
                        .HasForeignKey("RepresentationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SimpleIdServer.Scim.Domain.SCIMSchemaAttribute", "SchemaAttribute")
                        .WithMany()
                        .HasForeignKey("SchemaAttributeId");

                    b.Navigation("Representation");

                    b.Navigation("SchemaAttribute");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domain.SCIMSchemaAttribute", b =>
                {
                    b.HasOne("SimpleIdServer.Scim.Domain.SCIMSchema", null)
                        .WithMany("Attributes")
                        .HasForeignKey("SchemaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domain.SCIMSchemaExtension", b =>
                {
                    b.HasOne("SimpleIdServer.Scim.Domain.SCIMSchema", null)
                        .WithMany("SchemaExtensions")
                        .HasForeignKey("SCIMSchemaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domain.ProvisioningConfiguration", b =>
                {
                    b.Navigation("HistoryLst");

                    b.Navigation("Records");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domain.ProvisioningConfigurationRecord", b =>
                {
                    b.Navigation("Values");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domain.SCIMRepresentation", b =>
                {
                    b.Navigation("Attributes");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domain.SCIMSchema", b =>
                {
                    b.Navigation("Attributes");

                    b.Navigation("SchemaExtensions");
                });
#pragma warning restore 612, 618
        }
    }
}
