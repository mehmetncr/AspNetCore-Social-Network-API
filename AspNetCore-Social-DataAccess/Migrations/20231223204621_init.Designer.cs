﻿// <auto-generated />
using System;
using AspNetCore_Social_DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AspNetCore_Social_DataAccess.Migrations
{
    [DbContext(typeof(SocialContext))]
    [Migration("20231223204621_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AspNetCore_Social_DataAccess.Identity.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("AspNetCore_Social_DataAccess.Identity.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<string>("CommentContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CommentPostId")
                        .HasColumnType("int");

                    b.Property<int>("CommentUserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("CommentPostId");

                    b.HasIndex("CommentUserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.FriendRequest", b =>
                {
                    b.Property<int>("FriendReqId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FriendReqId"));

                    b.Property<DateTime>("FriendReqCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FriendReqFriendReqSenderId")
                        .HasColumnType("int");

                    b.Property<bool>("FriendReqStatus")
                        .HasColumnType("bit");

                    b.Property<int>("FriendReqUserId")
                        .HasColumnType("int");

                    b.HasKey("FriendReqId");

                    b.HasIndex("FriendReqFriendReqSenderId");

                    b.ToTable("FriendRequest");
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.Friends", b =>
                {
                    b.Property<int>("FriendsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FriendsId"));

                    b.Property<int>("FriendId")
                        .HasColumnType("int");

                    b.Property<int>("FriendsUserId")
                        .HasColumnType("int");

                    b.HasKey("FriendsId");

                    b.HasIndex("FriendId");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.Interest", b =>
                {
                    b.Property<int>("InterestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterestId"));

                    b.Property<string>("InterestName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("InterestId");

                    b.HasIndex("UserId");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OwnerUserId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.MessageDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MessageContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MessageId")
                        .HasColumnType("int");

                    b.Property<int>("OwnerUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("MessageDetail");
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.MessageInfo", b =>
                {
                    b.Property<int>("MessageInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageInfoId"));

                    b.Property<string>("MessageInfoContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MessageInfoCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MessageInfoMessageId")
                        .HasColumnType("int");

                    b.Property<int>("MessageInfoOwnerUserId")
                        .HasColumnType("int");

                    b.Property<int>("MessageInfoUserId")
                        .HasColumnType("int");

                    b.HasKey("MessageInfoId");

                    b.HasIndex("MessageInfoOwnerUserId");

                    b.ToTable("MessageInfos");
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"));

                    b.Property<string>("NotificationDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NotificationIsSeen")
                        .HasColumnType("bit");

                    b.Property<int>("NotificationOwnerUserId")
                        .HasColumnType("int");

                    b.Property<int>("NotificationSenderUserId")
                        .HasColumnType("int");

                    b.Property<string>("NotificationTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NotificationId");

                    b.HasIndex("NotificationSenderUserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostId"));

                    b.Property<int>("PostCommentNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostDislikeNumber")
                        .HasColumnType("int");

                    b.Property<string>("PostImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostLikeNumber")
                        .HasColumnType("int");

                    b.Property<string>("PostLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostTextContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostUserId")
                        .HasColumnType("int");

                    b.Property<string>("PostVideoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostYoutubeUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PostId");

                    b.HasIndex("PostUserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.PrivacySettings", b =>
                {
                    b.Property<int>("PrivacySettingsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrivacySettingsId"));

                    b.Property<bool>("PrivacySettingsFriendRequest")
                        .HasColumnType("bit");

                    b.Property<bool>("PrivacySettingsHiddenProfile")
                        .HasColumnType("bit");

                    b.Property<bool>("PrivacySettingsMessageRequest")
                        .HasColumnType("bit");

                    b.Property<int>("PrivacySettingsUserId")
                        .HasColumnType("int");

                    b.HasKey("PrivacySettingsId");

                    b.ToTable("PrivacySettings");
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.ReplyComment", b =>
                {
                    b.Property<int>("ReplyCommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReplyCommentId"));

                    b.Property<int>("ReplyCommentCommentId")
                        .HasColumnType("int");

                    b.Property<string>("ReplyCommentContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReplyCommentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReplyCommentUserId")
                        .HasColumnType("int");

                    b.HasKey("ReplyCommentId");

                    b.HasIndex("ReplyCommentCommentId");

                    b.HasIndex("ReplyCommentUserId");

                    b.ToTable("ReplyComments");
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.SocialMediaAccount", b =>
                {
                    b.Property<int>("SocialMediaAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SocialMediaAccountId"));

                    b.Property<string>("SocialMediaAccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SocialMediaAccountUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SocialMediaAccountUserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SocialMediaAccountId");

                    b.HasIndex("UserId");

                    b.ToTable("SocialMediaAccounts");
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("UserBiography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UserBirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserCoverPicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UserCreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserEducationInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserFollowerCount")
                        .HasColumnType("int");

                    b.Property<int?>("UserFollowingCount")
                        .HasColumnType("int");

                    b.Property<string>("UserGender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UserIsOnline")
                        .HasColumnType("bit");

                    b.Property<string>("UserJobInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserLanguage1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserLanguage2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserLanguage3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UserLastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserPrivacySettingsId")
                        .HasColumnType("int");

                    b.Property<string>("UserProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserWebsite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("UserPrivacySettingsId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.UserActivity", b =>
                {
                    b.Property<int>("UserActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserActivityId"));

                    b.Property<DateTime>("UserActivityDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserActivityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserActivityId");

                    b.HasIndex("UserId");

                    b.ToTable("UserActivities");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.Comment", b =>
                {
                    b.HasOne("AspNetCore_Social_Entity.Entities.Post", "CommentPost")
                        .WithMany("Comments")
                        .HasForeignKey("CommentPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspNetCore_Social_Entity.Entities.User", "CommentUser")
                        .WithMany("Comments")
                        .HasForeignKey("CommentUserId")
                        .IsRequired();

                    b.Navigation("CommentPost");

                    b.Navigation("CommentUser");
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.FriendRequest", b =>
                {
                    b.HasOne("AspNetCore_Social_Entity.Entities.User", "FriendReqFriendReqSender")
                        .WithMany("FriendRequests")
                        .HasForeignKey("FriendReqFriendReqSenderId")
                        .IsRequired();

                    b.Navigation("FriendReqFriendReqSender");
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.Friends", b =>
                {
                    b.HasOne("AspNetCore_Social_Entity.Entities.User", "Friend")
                        .WithMany("Friends")
                        .HasForeignKey("FriendId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Friend");
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.Interest", b =>
                {
                    b.HasOne("AspNetCore_Social_Entity.Entities.User", null)
                        .WithMany("Interests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.Message", b =>
                {
                    b.HasOne("AspNetCore_Social_Entity.Entities.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.MessageDetail", b =>
                {
                    b.HasOne("AspNetCore_Social_Entity.Entities.Message", "Message")
                        .WithMany("MessageDetails")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.MessageInfo", b =>
                {
                    b.HasOne("AspNetCore_Social_Entity.Entities.User", "MessageInfoOwnerUser")
                        .WithMany("MessageInfos")
                        .HasForeignKey("MessageInfoOwnerUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MessageInfoOwnerUser");
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.Notification", b =>
                {
                    b.HasOne("AspNetCore_Social_Entity.Entities.User", "NotificationSenderUser")
                        .WithMany("Notification")
                        .HasForeignKey("NotificationSenderUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NotificationSenderUser");
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.Post", b =>
                {
                    b.HasOne("AspNetCore_Social_Entity.Entities.User", "PostUser")
                        .WithMany("Posts")
                        .HasForeignKey("PostUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PostUser");
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.ReplyComment", b =>
                {
                    b.HasOne("AspNetCore_Social_Entity.Entities.Comment", "ReplyCommentComment")
                        .WithMany("ReplyComments")
                        .HasForeignKey("ReplyCommentCommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspNetCore_Social_Entity.Entities.User", "ReplyCommentUser")
                        .WithMany("ReplyComments")
                        .HasForeignKey("ReplyCommentUserId")
                        .IsRequired();

                    b.Navigation("ReplyCommentComment");

                    b.Navigation("ReplyCommentUser");
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.SocialMediaAccount", b =>
                {
                    b.HasOne("AspNetCore_Social_Entity.Entities.User", null)
                        .WithMany("SocialMediaAccounts")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.User", b =>
                {
                    b.HasOne("AspNetCore_Social_Entity.Entities.PrivacySettings", "UserPrivacySettings")
                        .WithMany()
                        .HasForeignKey("UserPrivacySettingsId");

                    b.Navigation("UserPrivacySettings");
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.UserActivity", b =>
                {
                    b.HasOne("AspNetCore_Social_Entity.Entities.User", null)
                        .WithMany("ActivityHistory")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("AspNetCore_Social_DataAccess.Identity.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("AspNetCore_Social_DataAccess.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("AspNetCore_Social_DataAccess.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("AspNetCore_Social_DataAccess.Identity.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspNetCore_Social_DataAccess.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("AspNetCore_Social_DataAccess.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.Comment", b =>
                {
                    b.Navigation("ReplyComments");
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.Message", b =>
                {
                    b.Navigation("MessageDetails");
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("AspNetCore_Social_Entity.Entities.User", b =>
                {
                    b.Navigation("ActivityHistory");

                    b.Navigation("Comments");

                    b.Navigation("FriendRequests");

                    b.Navigation("Friends");

                    b.Navigation("Interests");

                    b.Navigation("MessageInfos");

                    b.Navigation("Messages");

                    b.Navigation("Notification");

                    b.Navigation("Posts");

                    b.Navigation("ReplyComments");

                    b.Navigation("SocialMediaAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}
