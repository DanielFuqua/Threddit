USE [master]
GO

IF db_id('Threddit') IS NULL
  CREATE DATABASE Threddit
GO

USE [Threddit]
GO


DROP TABLE IF EXISTS [UserProfile];
DROP TABLE IF EXISTS [Thread];
DROP TABLE IF EXISTS [ThreadUser];
DROP TABLE IF EXISTS [Post];
DROP TABLE IF EXISTS [Comment];
DROP TABLE IF EXISTS [FollowUser];
DROP TABLE IF EXISTS [PostVote];
DROP TABLE IF EXISTS [CommentVote];

GO 


CREATE TABLE [UserProfile] (
  [Id] INTEGER IDENTITY PRIMARY KEY NOT NULL,
  [FirebaseUserId] NVARCHAR(28) NOT NULL,
  [UserName] NVARCHAR(50) NOT NULL,
  [Email] NVARCHAR(255) NOT NULL,
  [CreateDateTime] DATETIME NOT NULL,

  CONSTRAINT UQ_FirebaseUserId UNIQUE(FirebaseUserId)
)

CREATE TABLE [Thread] (
  [Id] INTEGER IDENTITY PRIMARY KEY NOT NULL,
  [Name] NVARCHAR(50) NOT NULL,
  [CreateDateTime] DATETIME NOT NULL
)


CREATE TABLE [ThreadUser] (
  [Id] INTEGER IDENTITY PRIMARY KEY NOT NULL,
  [ThreadId] INTEGER NOT NULL,
  [UserProfileId] INTEGER NOT NULL,
  [Moderator] BIT DEFAULT 0,
  [Creator] BIT DEFAULT 0,

  CONSTRAINT FK_ThreadUser_Thread FOREIGN KEY (ThreadId) REFERENCES Thread(id),
  CONSTRAINT FK_ThreadUser_UserProfile FOREIGN KEY (UserProfileId) REFERENCES UserProfile(id)
)

CREATE TABLE [Post] (
  [Id] INTEGER IDENTITY PRIMARY KEY NOT NULL,
  [Title] NVARCHAR(100) NOT NULL,
  [UserProfileId] INTEGER NOT NULL,
  [ThreadId] INTEGER NOT NULL,
  [Text] NVARCHAR(500) NULL,
  [Link] NVARCHAR(500) NULL,
  [ImagePath] NVARCHAR(500) NULL,
  [CreateDateTime] DATETIME NOT NULL,

  CONSTRAINT FK_Post_UserProfile FOREIGN KEY (UserProfileId) REFERENCES UserProfile(id),
  CONSTRAINT FK_Post_Thread FOREIGN KEY (ThreadId) REFERENCES Thread(id)
)


CREATE TABLE [Comment] (
  [Id] INTEGER IDENTITY PRIMARY KEY NOT NULL,
  [Text] NVARCHAR(300) NOT NULL,
  [CreateDateTime] DATETIME NOT NULL,
  [UserProfileId] INTEGER NOT NULL,
  [PostId] INTEGER NOT NULL,

  CONSTRAINT FK_Comment_UserProfile FOREIGN KEY (UserProfileId) REFERENCES UserProfile(id),
  CONSTRAINT FK_Comment_Post FOREIGN KEY (PostId) REFERENCES Post(id)
)

CREATE TABLE [FollowUser] (
  [Id] INTEGER IDENTITY PRIMARY KEY NOT NULL,
  [UserProfileId] INTEGER NOT NULL,
  [ActiveUserProfileId] INTEGER NOT NULL,

  CONSTRAINT FK_FollowUser_UserProfile FOREIGN KEY (UserProfileId) REFERENCES UserProfile(id),
  CONSTRAINT FK_FollowUser_ActiveUserProfile FOREIGN KEY (ActiveUserProfileId) REFERENCES UserProfile(id)

)

CREATE TABLE [PostVote] (
  [Id] INTEGER IDENTITY PRIMARY KEY NOT NULL,
  [UserProfileId] INTEGER NOT NULL,
  [PostId] INTEGER NOT NULL,
  [Vote] BIT DEFAULT NULL

  CONSTRAINT FK_PostVote_UserProfile FOREIGN KEY (UserProfileId) REFERENCES UserProfile(id),
  CONSTRAINT FK_PostVote_Post FOREIGN KEY (PostId) REFERENCES Post(id)
)

CREATE TABLE [CommentVote] (
  [Id] INTEGER IDENTITY PRIMARY KEY NOT NULL,
  [UserProfileId] INTEGER NOT NULL,
  [CommentId] INTEGER NOT NULL,
  [Vote] BIT DEFAULT NULL

  CONSTRAINT FK_CommentVote_UserProfile FOREIGN KEY (UserProfileId) REFERENCES UserProfile(id),
  CONSTRAINT FK_CommentVote_Comment FOREIGN KEY (CommentId) REFERENCES Comment(id)

)

GO


SET IDENTITY_INSERT [UserProfile] ON
INSERT INTO [UserProfile]
  ([Id], [FirebaseUserId], [UserName], [Email], [CreateDateTime])
VALUES
  (1, 'U1Gw35EYTIVQSUXtnif4nZvS3yH2', 'holden', 'holden@gmail.com', '2020-08-24 20:30:30'),
  (2, 'ygPYCGAf2ycVpuf4O0blnik67Uk1', 'daniel', 'daniel@gmail.com', '2020-08-24 20:30:30'),
  (3, 'cgbVPjg4xRPh8nB3ZxDGEpwEj352', 'suziQ', 'suzi@gmail.com', '2020-07-24 20:30:30'),
  (4, 'qysbg0zM00fPcp9xZTwX5HTAmKx1', 'benny', 'ben@gmail.com', '2020-07-24 20:30:30');
SET IDENTITY_INSERT [UserProfile] OFF

SET IDENTITY_INSERT [Thread] ON
INSERT INTO [Thread]
  ([Id], [Name], [CreateDateTime])
VALUES
  (1, 'carrots', '2020-07-31 20:30:30');
SET IDENTITY_INSERT [Thread] OFF


SET IDENTITY_INSERT [ThreadUser] ON
INSERT INTO [ThreadUser]
  ([Id], [ThreadId], [UserProfileId], [Moderator], [Creator])
VALUES
  (1, 1, 1, 1, 1),
  (2, 1, 2, 1, 0),
  (3, 1, 3, 0, 0);

SET IDENTITY_INSERT [ThreadUser] OFF


SET IDENTITY_INSERT [Post] ON
INSERT INTO [Post]
  ([Id], [Title], [UserProfileId], [ThreadId], [Text], [Link], [ImagePath], [CreateDateTime])
VALUES
  (1, 'Check out this albino carrot!', 1, 1, null, 'www.albinocarrot.com', null, '2020-08-24 20:30:30');
SET IDENTITY_INSERT [Post] OFF


SET IDENTITY_INSERT [Comment] ON
INSERT INTO [Comment]
  ([Id], [Text], [CreateDateTime], [PostId], [UserProfileId])
VALUES
  (1, 'My Mind is BLOWN!', '2020-08-24 20:30:30', 1, 2)
SET IDENTITY_INSERT [Comment] OFF


SET IDENTITY_INSERT [FollowUser] ON
INSERT INTO [FollowUser]
  ([Id], [UserProfileId], [ActiveUserProfileId])
VALUES
  (1, 2, 4);
SET IDENTITY_INSERT [FollowUser] OFF