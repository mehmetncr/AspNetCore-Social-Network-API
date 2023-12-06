using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCore_Social_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class editEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Users_UserId",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Interests_Users_UserId",
                table: "Interests");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivacySettings_Users_UserId",
                table: "PrivacySettings");

            migrationBuilder.DropForeignKey(
                name: "FK_ReplyComments_Comments_CommentId",
                table: "ReplyComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ReplyComments_Users_UserId",
                table: "ReplyComments");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialMediaAccounts_Users_UserId",
                table: "SocialMediaAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserActivities_Users_UserId",
                table: "UserActivities");

            migrationBuilder.DropIndex(
                name: "IX_Friends_UserId",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "TextContent",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "YoutubeUrl",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "Website",
                table: "Users",
                newName: "UserWebsite");

            migrationBuilder.RenameColumn(
                name: "ProfilePicture",
                table: "Users",
                newName: "UserProfilePicture");

            migrationBuilder.RenameColumn(
                name: "PrivacySettingsId",
                table: "Users",
                newName: "UserPrivacySettingsId");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Users",
                newName: "UserPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Users",
                newName: "UserLocation");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "UserLastName");

            migrationBuilder.RenameColumn(
                name: "LastLogin",
                table: "Users",
                newName: "UserLastLogin");

            migrationBuilder.RenameColumn(
                name: "Language3",
                table: "Users",
                newName: "UserLanguage3");

            migrationBuilder.RenameColumn(
                name: "Language2",
                table: "Users",
                newName: "UserLanguage2");

            migrationBuilder.RenameColumn(
                name: "Language1",
                table: "Users",
                newName: "UserLanguage1");

            migrationBuilder.RenameColumn(
                name: "JobInfo",
                table: "Users",
                newName: "UserJobInfo");

            migrationBuilder.RenameColumn(
                name: "IsOnline",
                table: "Users",
                newName: "UserIsOnline");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Users",
                newName: "UserFirstName");

            migrationBuilder.RenameColumn(
                name: "FollowingCount",
                table: "Users",
                newName: "UserFollowingCount");

            migrationBuilder.RenameColumn(
                name: "FollowerCount",
                table: "Users",
                newName: "UserFollowerCount");

            migrationBuilder.RenameColumn(
                name: "EducationInfo",
                table: "Users",
                newName: "UserGender");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Users",
                newName: "UserCreatedAt");

            migrationBuilder.RenameColumn(
                name: "CoverPicture",
                table: "Users",
                newName: "UserEducationInfo");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Users",
                newName: "UserBirthDate");

            migrationBuilder.RenameColumn(
                name: "Biography",
                table: "Users",
                newName: "UserCoverPicture");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserActivities",
                newName: "UserActivityUserId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UserActivities",
                newName: "UserActivityName");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "UserActivities",
                newName: "UserActivityDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserActivities",
                newName: "UserActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_UserActivities_UserId",
                table: "UserActivities",
                newName: "IX_UserActivities_UserActivityUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "SocialMediaAccounts",
                newName: "SocialMediaAccountUserId");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "SocialMediaAccounts",
                newName: "SocialMediaAccountUrl");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SocialMediaAccounts",
                newName: "SocialMediaAccountName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SocialMediaAccounts",
                newName: "SocialMediaAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_SocialMediaAccounts_UserId",
                table: "SocialMediaAccounts",
                newName: "IX_SocialMediaAccounts_SocialMediaAccountUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ReplyComments",
                newName: "ReplyCommentUserId");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "ReplyComments",
                newName: "ReplyCommentContent");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "ReplyComments",
                newName: "ReplyCommentCommentId");

            migrationBuilder.RenameColumn(
                name: "CommentDate",
                table: "ReplyComments",
                newName: "ReplyCommentDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ReplyComments",
                newName: "ReplyCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_ReplyComments_UserId",
                table: "ReplyComments",
                newName: "IX_ReplyComments_ReplyCommentUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ReplyComments_CommentId",
                table: "ReplyComments",
                newName: "IX_ReplyComments_ReplyCommentCommentId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PrivacySettings",
                newName: "PrivacySettingsUserId");

            migrationBuilder.RenameColumn(
                name: "MessageRequest",
                table: "PrivacySettings",
                newName: "PrivacySettingsMessageRequest");

            migrationBuilder.RenameColumn(
                name: "HiddenProfile",
                table: "PrivacySettings",
                newName: "PrivacySettingsHiddenProfile");

            migrationBuilder.RenameColumn(
                name: "FriendRequest",
                table: "PrivacySettings",
                newName: "PrivacySettingsFriendRequest");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PrivacySettings",
                newName: "PrivacySettingsId");

            migrationBuilder.RenameIndex(
                name: "IX_PrivacySettings_UserId",
                table: "PrivacySettings",
                newName: "IX_PrivacySettings_PrivacySettingsUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Posts",
                newName: "PostUserId");

            migrationBuilder.RenameColumn(
                name: "LikeNumber",
                table: "Posts",
                newName: "PostLikeNumber");

            migrationBuilder.RenameColumn(
                name: "DislikeNumber",
                table: "Posts",
                newName: "PostDislikeNumber");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Posts",
                newName: "PostCreateDate");

            migrationBuilder.RenameColumn(
                name: "CommentNumber",
                table: "Posts",
                newName: "PostCommentNumber");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Posts",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                newName: "IX_Posts_PostUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Notifications",
                newName: "NotificationUserId");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Notifications",
                newName: "NotificationTitle");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Notifications",
                newName: "NotificationDescription");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Notifications",
                newName: "NotificationId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                newName: "IX_Notifications_NotificationUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Interests",
                newName: "InterestUserId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Interests",
                newName: "InterestName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Interests",
                newName: "InterestId");

            migrationBuilder.RenameIndex(
                name: "IX_Interests_UserId",
                table: "Interests",
                newName: "IX_Interests_InterestUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Friends",
                newName: "FriendId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Friends",
                newName: "FriendsId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comments",
                newName: "CommentUserId");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Comments",
                newName: "CommentPostId");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Comments",
                newName: "CommentContent");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                newName: "IX_Comments_CommentUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                newName: "IX_Comments_CommentPostId");

            migrationBuilder.AddColumn<string>(
                name: "UserBiography",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostImageUrl",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostTextContent",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostVideoUrl",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostYoutubeUrl",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Friends_FriendsUserId",
                table: "Friends",
                column: "FriendsUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_CommentPostId",
                table: "Comments",
                column: "CommentPostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_CommentUserId",
                table: "Comments",
                column: "CommentUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Users_FriendsUserId",
                table: "Friends",
                column: "FriendsUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_Users_InterestUserId",
                table: "Interests",
                column: "InterestUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_NotificationUserId",
                table: "Notifications",
                column: "NotificationUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_PostUserId",
                table: "Posts",
                column: "PostUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrivacySettings_Users_PrivacySettingsUserId",
                table: "PrivacySettings",
                column: "PrivacySettingsUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReplyComments_Comments_ReplyCommentCommentId",
                table: "ReplyComments",
                column: "ReplyCommentCommentId",
                principalTable: "Comments",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReplyComments_Users_ReplyCommentUserId",
                table: "ReplyComments",
                column: "ReplyCommentUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMediaAccounts_Users_SocialMediaAccountUserId",
                table: "SocialMediaAccounts",
                column: "SocialMediaAccountUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserActivities_Users_UserActivityUserId",
                table: "UserActivities",
                column: "UserActivityUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_CommentPostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_CommentUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Users_FriendsUserId",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Interests_Users_InterestUserId",
                table: "Interests");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_NotificationUserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_PostUserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivacySettings_Users_PrivacySettingsUserId",
                table: "PrivacySettings");

            migrationBuilder.DropForeignKey(
                name: "FK_ReplyComments_Comments_ReplyCommentCommentId",
                table: "ReplyComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ReplyComments_Users_ReplyCommentUserId",
                table: "ReplyComments");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialMediaAccounts_Users_SocialMediaAccountUserId",
                table: "SocialMediaAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserActivities_Users_UserActivityUserId",
                table: "UserActivities");

            migrationBuilder.DropIndex(
                name: "IX_Friends_FriendsUserId",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "UserBiography",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PostImageUrl",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostTextContent",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostVideoUrl",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostYoutubeUrl",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "UserWebsite",
                table: "Users",
                newName: "Website");

            migrationBuilder.RenameColumn(
                name: "UserProfilePicture",
                table: "Users",
                newName: "ProfilePicture");

            migrationBuilder.RenameColumn(
                name: "UserPrivacySettingsId",
                table: "Users",
                newName: "PrivacySettingsId");

            migrationBuilder.RenameColumn(
                name: "UserPhoneNumber",
                table: "Users",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "UserLocation",
                table: "Users",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "UserLastName",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "UserLastLogin",
                table: "Users",
                newName: "LastLogin");

            migrationBuilder.RenameColumn(
                name: "UserLanguage3",
                table: "Users",
                newName: "Language3");

            migrationBuilder.RenameColumn(
                name: "UserLanguage2",
                table: "Users",
                newName: "Language2");

            migrationBuilder.RenameColumn(
                name: "UserLanguage1",
                table: "Users",
                newName: "Language1");

            migrationBuilder.RenameColumn(
                name: "UserJobInfo",
                table: "Users",
                newName: "JobInfo");

            migrationBuilder.RenameColumn(
                name: "UserIsOnline",
                table: "Users",
                newName: "IsOnline");

            migrationBuilder.RenameColumn(
                name: "UserGender",
                table: "Users",
                newName: "EducationInfo");

            migrationBuilder.RenameColumn(
                name: "UserFollowingCount",
                table: "Users",
                newName: "FollowingCount");

            migrationBuilder.RenameColumn(
                name: "UserFollowerCount",
                table: "Users",
                newName: "FollowerCount");

            migrationBuilder.RenameColumn(
                name: "UserFirstName",
                table: "Users",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "UserEducationInfo",
                table: "Users",
                newName: "CoverPicture");

            migrationBuilder.RenameColumn(
                name: "UserCreatedAt",
                table: "Users",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "UserCoverPicture",
                table: "Users",
                newName: "Biography");

            migrationBuilder.RenameColumn(
                name: "UserBirthDate",
                table: "Users",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserActivityUserId",
                table: "UserActivities",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserActivityName",
                table: "UserActivities",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "UserActivityDate",
                table: "UserActivities",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "UserActivityId",
                table: "UserActivities",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_UserActivities_UserActivityUserId",
                table: "UserActivities",
                newName: "IX_UserActivities_UserId");

            migrationBuilder.RenameColumn(
                name: "SocialMediaAccountUserId",
                table: "SocialMediaAccounts",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "SocialMediaAccountUrl",
                table: "SocialMediaAccounts",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "SocialMediaAccountName",
                table: "SocialMediaAccounts",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "SocialMediaAccountId",
                table: "SocialMediaAccounts",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_SocialMediaAccounts_SocialMediaAccountUserId",
                table: "SocialMediaAccounts",
                newName: "IX_SocialMediaAccounts_UserId");

            migrationBuilder.RenameColumn(
                name: "ReplyCommentUserId",
                table: "ReplyComments",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ReplyCommentDate",
                table: "ReplyComments",
                newName: "CommentDate");

            migrationBuilder.RenameColumn(
                name: "ReplyCommentContent",
                table: "ReplyComments",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "ReplyCommentCommentId",
                table: "ReplyComments",
                newName: "CommentId");

            migrationBuilder.RenameColumn(
                name: "ReplyCommentId",
                table: "ReplyComments",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ReplyComments_ReplyCommentUserId",
                table: "ReplyComments",
                newName: "IX_ReplyComments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ReplyComments_ReplyCommentCommentId",
                table: "ReplyComments",
                newName: "IX_ReplyComments_CommentId");

            migrationBuilder.RenameColumn(
                name: "PrivacySettingsUserId",
                table: "PrivacySettings",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "PrivacySettingsMessageRequest",
                table: "PrivacySettings",
                newName: "MessageRequest");

            migrationBuilder.RenameColumn(
                name: "PrivacySettingsHiddenProfile",
                table: "PrivacySettings",
                newName: "HiddenProfile");

            migrationBuilder.RenameColumn(
                name: "PrivacySettingsFriendRequest",
                table: "PrivacySettings",
                newName: "FriendRequest");

            migrationBuilder.RenameColumn(
                name: "PrivacySettingsId",
                table: "PrivacySettings",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_PrivacySettings_PrivacySettingsUserId",
                table: "PrivacySettings",
                newName: "IX_PrivacySettings_UserId");

            migrationBuilder.RenameColumn(
                name: "PostUserId",
                table: "Posts",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "PostLikeNumber",
                table: "Posts",
                newName: "LikeNumber");

            migrationBuilder.RenameColumn(
                name: "PostDislikeNumber",
                table: "Posts",
                newName: "DislikeNumber");

            migrationBuilder.RenameColumn(
                name: "PostCreateDate",
                table: "Posts",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "PostCommentNumber",
                table: "Posts",
                newName: "CommentNumber");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Posts",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_PostUserId",
                table: "Posts",
                newName: "IX_Posts_UserId");

            migrationBuilder.RenameColumn(
                name: "NotificationUserId",
                table: "Notifications",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "NotificationTitle",
                table: "Notifications",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "NotificationDescription",
                table: "Notifications",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "NotificationId",
                table: "Notifications",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_NotificationUserId",
                table: "Notifications",
                newName: "IX_Notifications_UserId");

            migrationBuilder.RenameColumn(
                name: "InterestUserId",
                table: "Interests",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "InterestName",
                table: "Interests",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "InterestId",
                table: "Interests",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Interests_InterestUserId",
                table: "Interests",
                newName: "IX_Interests_UserId");

            migrationBuilder.RenameColumn(
                name: "FriendId",
                table: "Friends",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "FriendsId",
                table: "Friends",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CommentUserId",
                table: "Comments",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CommentPostId",
                table: "Comments",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "CommentContent",
                table: "Comments",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Comments",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CommentUserId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CommentPostId",
                table: "Comments",
                newName: "IX_Comments_PostId");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TextContent",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "YoutubeUrl",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserId",
                table: "Friends",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Users_UserId",
                table: "Friends",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_Users_UserId",
                table: "Interests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrivacySettings_Users_UserId",
                table: "PrivacySettings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReplyComments_Comments_CommentId",
                table: "ReplyComments",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReplyComments_Users_UserId",
                table: "ReplyComments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMediaAccounts_Users_UserId",
                table: "SocialMediaAccounts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserActivities_Users_UserId",
                table: "UserActivities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
