﻿// <auto-generated />
using System;
using EventMaster.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventMaster.Infrastucture.Migrations
{
    [DbContext(typeof(EventMasterDbContext))]
    partial class EventMasterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EventMaster.Domain.EventReviews.EventReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("GuestId")
                        .HasColumnType("int");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("GuestId");

                    b.ToTable("EventReviews");
                });

            modelBuilder.Entity("EventMaster.Domain.Events.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("EveryoneAllowed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("State")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EventMaster.Domain.Events.EventGuest", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("GuestId")
                        .HasColumnType("int");

                    b.HasKey("EventId", "GuestId");

                    b.HasIndex("GuestId");

                    b.ToTable("EventGuest");
                });

            modelBuilder.Entity("EventMaster.Domain.Events.EventHost", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("HostId")
                        .HasColumnType("int");

                    b.HasKey("EventId", "HostId");

                    b.HasIndex("HostId");

                    b.ToTable("EventHost");
                });

            modelBuilder.Entity("EventMaster.Domain.Reservations.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Accepted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("GuestId")
                        .HasColumnType("int");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.HasIndex("TicketId")
                        .IsUnique();

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("EventMaster.Domain.Tickets.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("EventMaster.Domain.Topics.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("EventMaster.Domain.Users.FollowerFollowing", b =>
                {
                    b.Property<int>("FollowerId")
                        .HasColumnType("int");

                    b.Property<int>("FollowingId")
                        .HasColumnType("int");

                    b.HasKey("FollowerId", "FollowingId");

                    b.HasIndex("FollowingId");

                    b.ToTable("FollowerFollowing");
                });

            modelBuilder.Entity("EventMaster.Domain.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EventMaster.Domain.EventReviews.EventReview", b =>
                {
                    b.HasOne("EventMaster.Domain.Events.Event", "Event")
                        .WithMany("EventReviews")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventMaster.Domain.Users.User", "Guest")
                        .WithMany("EventsReviews")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Guest");
                });

            modelBuilder.Entity("EventMaster.Domain.Events.EventGuest", b =>
                {
                    b.HasOne("EventMaster.Domain.Events.Event", "Event")
                        .WithMany("Guests")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventMaster.Domain.Users.User", "Guest")
                        .WithMany("EventsToAttend")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Guest");
                });

            modelBuilder.Entity("EventMaster.Domain.Events.EventHost", b =>
                {
                    b.HasOne("EventMaster.Domain.Events.Event", "Event")
                        .WithMany("Hosts")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventMaster.Domain.Users.User", "Host")
                        .WithMany("EventsToHost")
                        .HasForeignKey("HostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Host");
                });

            modelBuilder.Entity("EventMaster.Domain.Reservations.Reservation", b =>
                {
                    b.HasOne("EventMaster.Domain.Users.User", "Guest")
                        .WithMany("Reservations")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventMaster.Domain.Tickets.Ticket", "Ticket")
                        .WithOne("Reservation")
                        .HasForeignKey("EventMaster.Domain.Reservations.Reservation", "TicketId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Guest");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("EventMaster.Domain.Tickets.Ticket", b =>
                {
                    b.HasOne("EventMaster.Domain.Events.Event", "Event")
                        .WithMany("Tickets")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("EventMaster.Domain.Topics.Topic", b =>
                {
                    b.HasOne("EventMaster.Domain.Events.Event", "Event")
                        .WithMany("Topics")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("EventMaster.Domain.Users.FollowerFollowing", b =>
                {
                    b.HasOne("EventMaster.Domain.Users.User", "Follower")
                        .WithMany("Followings")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventMaster.Domain.Users.User", "Following")
                        .WithMany("Followers")
                        .HasForeignKey("FollowingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Follower");

                    b.Navigation("Following");
                });

            modelBuilder.Entity("EventMaster.Domain.Events.Event", b =>
                {
                    b.Navigation("EventReviews");

                    b.Navigation("Guests");

                    b.Navigation("Hosts");

                    b.Navigation("Tickets");

                    b.Navigation("Topics");
                });

            modelBuilder.Entity("EventMaster.Domain.Tickets.Ticket", b =>
                {
                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("EventMaster.Domain.Users.User", b =>
                {
                    b.Navigation("EventsReviews");

                    b.Navigation("EventsToAttend");

                    b.Navigation("EventsToHost");

                    b.Navigation("Followers");

                    b.Navigation("Followings");

                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}