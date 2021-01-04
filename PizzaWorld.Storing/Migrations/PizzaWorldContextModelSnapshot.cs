using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaWorld.Storing;

namespace PizzaWorld.Storing.Migrations
{
    [DbContext(typeof(PizzaWorldContext))]
    partial class PizzaWorldContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("PizzaWorld.Domain.Models.Crust", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("EntityID");

                    b.ToTable("Crusts");

                    b.HasData(
                        new
                        {
                            EntityID = 1L,
                            Name = "regular",
                            Price = 1.0
                        },
                        new
                        {
                            EntityID = 2L,
                            Name = "thin",
                            Price = 1.5
                        },
                        new
                        {
                            EntityID = 3L,
                            Name = "pan",
                            Price = 1.75
                        });
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Order", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<long>("StoreID")
                        .HasColumnType("bigint");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("EntityID");

                    b.HasIndex("StoreID");

                    b.HasIndex("UserID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Pizza", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("CrustEntityID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("OrderEntityID")
                        .HasColumnType("bigint");

                    b.Property<long?>("SizeEntityID")
                        .HasColumnType("bigint");

                    b.HasKey("EntityID");

                    b.HasIndex("CrustEntityID");

                    b.HasIndex("OrderEntityID");

                    b.HasIndex("SizeEntityID");

                    b.ToTable("Pizza");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Size", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("EntityID");

                    b.ToTable("Sizes");

                    b.HasData(
                        new
                        {
                            EntityID = 1L,
                            Name = "regular",
                            Price = 1.0
                        },
                        new
                        {
                            EntityID = 2L,
                            Name = "medium",
                            Price = 2.0
                        },
                        new
                        {
                            EntityID = 3L,
                            Name = "large",
                            Price = 3.0
                        });
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Store", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityID");

                    b.ToTable("Stores");

                    b.HasData(
                        new
                        {
                            EntityID = 1L,
                            Name = "Domino's"
                        },
                        new
                        {
                            EntityID = 2L,
                            Name = "Pizza Hut"
                        },
                        new
                        {
                            EntityID = 3L,
                            Name = "Papa John's"
                        },
                        new
                        {
                            EntityID = 4L,
                            Name = "Generic Pizza Place"
                        });
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Topping", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PizzaEntityID")
                        .HasColumnType("bigint");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("EntityID");

                    b.HasIndex("PizzaEntityID");

                    b.ToTable("Toppings");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.User", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            EntityID = 1L,
                            Name = "admin"
                        });
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Order", b =>
                {
                    b.HasOne("PizzaWorld.Domain.Models.Store", null)
                        .WithMany("Orders")
                        .HasForeignKey("StoreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaWorld.Domain.Models.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Pizza", b =>
                {
                    b.HasOne("PizzaWorld.Domain.Models.Crust", "Crust")
                        .WithMany()
                        .HasForeignKey("CrustEntityID");

                    b.HasOne("PizzaWorld.Domain.Models.Order", null)
                        .WithMany("Pizzas")
                        .HasForeignKey("OrderEntityID");

                    b.HasOne("PizzaWorld.Domain.Models.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeEntityID");

                    b.Navigation("Crust");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Topping", b =>
                {
                    b.HasOne("PizzaWorld.Domain.Models.Pizza", null)
                        .WithMany("Toppings")
                        .HasForeignKey("PizzaEntityID");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Order", b =>
                {
                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Pizza", b =>
                {
                    b.Navigation("Toppings");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.Store", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PizzaWorld.Domain.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
