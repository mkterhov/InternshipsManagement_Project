
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/07/2018 17:11:49
-- Generated from EDMX file: E:\Stuff\VisualStudio Projects\InternshipsManagement_Project\InternshipsManagmentProject.Data\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [InternshipsManagmentProjectDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AspNetUsers_Images]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUsers] DROP CONSTRAINT [FK_AspNetUsers_Images];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_Emails_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Emails] DROP CONSTRAINT [FK_Emails_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_Emails_AspNetUsers1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Emails] DROP CONSTRAINT [FK_Emails_AspNetUsers1];
GO
IF OBJECT_ID(N'[dbo].[FK_Firms_Images]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Firms] DROP CONSTRAINT [FK_Firms_Images];
GO
IF OBJECT_ID(N'[dbo].[FK_Images_Files]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Images] DROP CONSTRAINT [FK_Images_Files];
GO
IF OBJECT_ID(N'[dbo].[FK_Internships_Firms1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Internships] DROP CONSTRAINT [FK_Internships_Firms1];
GO
IF OBJECT_ID(N'[dbo].[FK_Internships_Images]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Internships] DROP CONSTRAINT [FK_Internships_Images];
GO
IF OBJECT_ID(N'[dbo].[FK_Internships_Recruiters1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Internships] DROP CONSTRAINT [FK_Internships_Recruiters1];
GO
IF OBJECT_ID(N'[dbo].[FK_Recruiters_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Recruiters] DROP CONSTRAINT [FK_Recruiters_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_Recruiters_Firms]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Recruiters] DROP CONSTRAINT [FK_Recruiters_Firms];
GO
IF OBJECT_ID(N'[dbo].[FK_Resumes_Files]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Resumes] DROP CONSTRAINT [FK_Resumes_Files];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentInternship_Internships1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentInternship] DROP CONSTRAINT [FK_StudentInternship_Internships1];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentInternship_Resumes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentInternship] DROP CONSTRAINT [FK_StudentInternship_Resumes];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentInternship_Students1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentInternship] DROP CONSTRAINT [FK_StudentInternship_Students1];
GO
IF OBJECT_ID(N'[dbo].[FK_Students_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Students] DROP CONSTRAINT [FK_Students_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_Students_Resumes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Students] DROP CONSTRAINT [FK_Students_Resumes];
GO
IF OBJECT_ID(N'[dbo].[FK_UserResumeMapTable_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserResumeMapTable] DROP CONSTRAINT [FK_UserResumeMapTable_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_UserResumeMapTable_Resumes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserResumeMapTable] DROP CONSTRAINT [FK_UserResumeMapTable_Resumes];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[Emails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Emails];
GO
IF OBJECT_ID(N'[dbo].[Files]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Files];
GO
IF OBJECT_ID(N'[dbo].[Firms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Firms];
GO
IF OBJECT_ID(N'[dbo].[Images]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Images];
GO
IF OBJECT_ID(N'[dbo].[Internships]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Internships];
GO
IF OBJECT_ID(N'[dbo].[Recruiters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Recruiters];
GO
IF OBJECT_ID(N'[dbo].[Resumes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Resumes];
GO
IF OBJECT_ID(N'[dbo].[StudentInternship]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentInternship];
GO
IF OBJECT_ID(N'[dbo].[Students]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Students];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[UserResumeMapTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserResumeMapTable];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL,
    [ProfilePhoto] nvarchar(128)  NULL
);
GO

-- Creating table 'Emails'
CREATE TABLE [dbo].[Emails] (
    [Id] nvarchar(128)  NOT NULL,
    [From] nvarchar(256)  NOT NULL,
    [To] nvarchar(256)  NOT NULL,
    [Subject] nvarchar(256)  NULL,
    [Content] nvarchar(1024)  NOT NULL,
    [SenderId] nvarchar(128)  NOT NULL,
    [ReceiverId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'Files'
CREATE TABLE [dbo].[Files] (
    [FileId] nvarchar(128)  NOT NULL,
    [FileName] nvarchar(150)  NOT NULL,
    [FileExtension] nvarchar(10)  NOT NULL,
    [Size] bigint  NULL,
    [Image] varbinary(max)  NULL,
    [File1] varbinary(max)  NULL
);
GO

-- Creating table 'Firms'
CREATE TABLE [dbo].[Firms] (
    [FirmId] nvarchar(128)  NOT NULL,
    [Name] varchar(150)  NULL,
    [Description] varchar(150)  NULL,
    [NumberOfEmployees] int  NULL,
    [Logo] nvarchar(128)  NULL
);
GO

-- Creating table 'Images'
CREATE TABLE [dbo].[Images] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(120)  NOT NULL,
    [Path] nvarchar(max)  NULL,
    [File] nvarchar(128)  NULL
);
GO

-- Creating table 'Internships'
CREATE TABLE [dbo].[Internships] (
    [InternshipId] nvarchar(128)  NOT NULL,
    [FirmOrganizerId] nvarchar(128)  NOT NULL,
    [RecruiterResponsibleId] nvarchar(128)  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [Description] varchar(150)  NOT NULL,
    [City] varchar(150)  NULL,
    [PositionsAvailable] int  NULL,
    [InternshipPostPhoto] nvarchar(128)  NULL,
    [Category] varchar(150)  NOT NULL,
    [Title] nvarchar(150)  NOT NULL
);
GO

-- Creating table 'Recruiters'
CREATE TABLE [dbo].[Recruiters] (
    [RecruiterId] nvarchar(128)  NOT NULL,
    [Name] varchar(150)  NULL,
    [LastName] varchar(150)  NULL,
    [FirmId] nvarchar(128)  NOT NULL,
    [ContactEmail] varchar(150)  NULL,
    [Bio] varchar(250)  NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'Resumes'
CREATE TABLE [dbo].[Resumes] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(150)  NOT NULL,
    [Path] nvarchar(max)  NULL,
    [File] nvarchar(128)  NULL
);
GO

-- Creating table 'StudentInternships'
CREATE TABLE [dbo].[StudentInternships] (
    [StudentId] nvarchar(128)  NOT NULL,
    [InternshipId] nvarchar(128)  NOT NULL,
    [StudentUserId] nvarchar(128)  NOT NULL,
    [DateCreated] datetime  NULL,
    [Completed] bit  NULL,
    [Updates] varchar(400)  NULL,
    [SubmitedResume] nvarchar(128)  NULL,
    [StatusOfApplication] bit  NULL,
    [StudentResumeId] nvarchar(128)  NULL,
    [StarredForFurtherReview] bit  NULL
);
GO

-- Creating table 'Students'
CREATE TABLE [dbo].[Students] (
    [StudentId] nvarchar(128)  NOT NULL,
    [Name] varchar(150)  NOT NULL,
    [LastName] varchar(150)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [University] varchar(150)  NULL,
    [Domain] varchar(150)  NULL,
    [Bio] varchar(350)  NULL,
    [Birthday] datetime  NOT NULL,
    [LevelOfStudies] varchar(100)  NULL,
    [Available] bit  NULL,
    [StudentCV] nvarchar(128)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'UserResumeMapTable'
CREATE TABLE [dbo].[UserResumeMapTable] (
    [AspNetUsers_Id] nvarchar(128)  NOT NULL,
    [Resumes_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Emails'
ALTER TABLE [dbo].[Emails]
ADD CONSTRAINT [PK_Emails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [FileId] in table 'Files'
ALTER TABLE [dbo].[Files]
ADD CONSTRAINT [PK_Files]
    PRIMARY KEY CLUSTERED ([FileId] ASC);
GO

-- Creating primary key on [FirmId] in table 'Firms'
ALTER TABLE [dbo].[Firms]
ADD CONSTRAINT [PK_Firms]
    PRIMARY KEY CLUSTERED ([FirmId] ASC);
GO

-- Creating primary key on [Id] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [PK_Images]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [InternshipId] in table 'Internships'
ALTER TABLE [dbo].[Internships]
ADD CONSTRAINT [PK_Internships]
    PRIMARY KEY CLUSTERED ([InternshipId] ASC);
GO

-- Creating primary key on [RecruiterId] in table 'Recruiters'
ALTER TABLE [dbo].[Recruiters]
ADD CONSTRAINT [PK_Recruiters]
    PRIMARY KEY CLUSTERED ([RecruiterId] ASC);
GO

-- Creating primary key on [Id] in table 'Resumes'
ALTER TABLE [dbo].[Resumes]
ADD CONSTRAINT [PK_Resumes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [StudentId], [InternshipId] in table 'StudentInternships'
ALTER TABLE [dbo].[StudentInternships]
ADD CONSTRAINT [PK_StudentInternships]
    PRIMARY KEY CLUSTERED ([StudentId], [InternshipId] ASC);
GO

-- Creating primary key on [StudentId] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [PK_Students]
    PRIMARY KEY CLUSTERED ([StudentId] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- Creating primary key on [AspNetUsers_Id], [Resumes_Id] in table 'UserResumeMapTable'
ALTER TABLE [dbo].[UserResumeMapTable]
ADD CONSTRAINT [PK_UserResumeMapTable]
    PRIMARY KEY CLUSTERED ([AspNetUsers_Id], [Resumes_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [ProfilePhoto] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [FK_AspNetUsers_Images]
    FOREIGN KEY ([ProfilePhoto])
    REFERENCES [dbo].[Images]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUsers_Images'
CREATE INDEX [IX_FK_AspNetUsers_Images]
ON [dbo].[AspNetUsers]
    ([ProfilePhoto]);
GO

-- Creating foreign key on [ReceiverId] in table 'Emails'
ALTER TABLE [dbo].[Emails]
ADD CONSTRAINT [FK_Emails_AspNetUsers]
    FOREIGN KEY ([ReceiverId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Emails_AspNetUsers'
CREATE INDEX [IX_FK_Emails_AspNetUsers]
ON [dbo].[Emails]
    ([ReceiverId]);
GO

-- Creating foreign key on [SenderId] in table 'Emails'
ALTER TABLE [dbo].[Emails]
ADD CONSTRAINT [FK_Emails_AspNetUsers1]
    FOREIGN KEY ([SenderId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Emails_AspNetUsers1'
CREATE INDEX [IX_FK_Emails_AspNetUsers1]
ON [dbo].[Emails]
    ([SenderId]);
GO

-- Creating foreign key on [UserId] in table 'Recruiters'
ALTER TABLE [dbo].[Recruiters]
ADD CONSTRAINT [FK_Recruiters_AspNetUsers]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Recruiters_AspNetUsers'
CREATE INDEX [IX_FK_Recruiters_AspNetUsers]
ON [dbo].[Recruiters]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [FK_Students_AspNetUsers]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Students_AspNetUsers'
CREATE INDEX [IX_FK_Students_AspNetUsers]
ON [dbo].[Students]
    ([UserId]);
GO

-- Creating foreign key on [File] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [FK_Images_Files]
    FOREIGN KEY ([File])
    REFERENCES [dbo].[Files]
        ([FileId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Images_Files'
CREATE INDEX [IX_FK_Images_Files]
ON [dbo].[Images]
    ([File]);
GO

-- Creating foreign key on [File] in table 'Resumes'
ALTER TABLE [dbo].[Resumes]
ADD CONSTRAINT [FK_Resumes_Files]
    FOREIGN KEY ([File])
    REFERENCES [dbo].[Files]
        ([FileId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Resumes_Files'
CREATE INDEX [IX_FK_Resumes_Files]
ON [dbo].[Resumes]
    ([File]);
GO

-- Creating foreign key on [Logo] in table 'Firms'
ALTER TABLE [dbo].[Firms]
ADD CONSTRAINT [FK_Firms_Images]
    FOREIGN KEY ([Logo])
    REFERENCES [dbo].[Images]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Firms_Images'
CREATE INDEX [IX_FK_Firms_Images]
ON [dbo].[Firms]
    ([Logo]);
GO

-- Creating foreign key on [FirmOrganizerId] in table 'Internships'
ALTER TABLE [dbo].[Internships]
ADD CONSTRAINT [FK_Internships_Firms1]
    FOREIGN KEY ([FirmOrganizerId])
    REFERENCES [dbo].[Firms]
        ([FirmId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Internships_Firms1'
CREATE INDEX [IX_FK_Internships_Firms1]
ON [dbo].[Internships]
    ([FirmOrganizerId]);
GO

-- Creating foreign key on [FirmId] in table 'Recruiters'
ALTER TABLE [dbo].[Recruiters]
ADD CONSTRAINT [FK_Recruiters_Firms]
    FOREIGN KEY ([FirmId])
    REFERENCES [dbo].[Firms]
        ([FirmId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Recruiters_Firms'
CREATE INDEX [IX_FK_Recruiters_Firms]
ON [dbo].[Recruiters]
    ([FirmId]);
GO

-- Creating foreign key on [InternshipPostPhoto] in table 'Internships'
ALTER TABLE [dbo].[Internships]
ADD CONSTRAINT [FK_Internships_Images]
    FOREIGN KEY ([InternshipPostPhoto])
    REFERENCES [dbo].[Images]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Internships_Images'
CREATE INDEX [IX_FK_Internships_Images]
ON [dbo].[Internships]
    ([InternshipPostPhoto]);
GO

-- Creating foreign key on [RecruiterResponsibleId] in table 'Internships'
ALTER TABLE [dbo].[Internships]
ADD CONSTRAINT [FK_Internships_Recruiters1]
    FOREIGN KEY ([RecruiterResponsibleId])
    REFERENCES [dbo].[Recruiters]
        ([RecruiterId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Internships_Recruiters1'
CREATE INDEX [IX_FK_Internships_Recruiters1]
ON [dbo].[Internships]
    ([RecruiterResponsibleId]);
GO

-- Creating foreign key on [InternshipId] in table 'StudentInternships'
ALTER TABLE [dbo].[StudentInternships]
ADD CONSTRAINT [FK_StudentInternship_Internships1]
    FOREIGN KEY ([InternshipId])
    REFERENCES [dbo].[Internships]
        ([InternshipId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentInternship_Internships1'
CREATE INDEX [IX_FK_StudentInternship_Internships1]
ON [dbo].[StudentInternships]
    ([InternshipId]);
GO

-- Creating foreign key on [SubmitedResume] in table 'StudentInternships'
ALTER TABLE [dbo].[StudentInternships]
ADD CONSTRAINT [FK_StudentInternship_Resumes]
    FOREIGN KEY ([SubmitedResume])
    REFERENCES [dbo].[Resumes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentInternship_Resumes'
CREATE INDEX [IX_FK_StudentInternship_Resumes]
ON [dbo].[StudentInternships]
    ([SubmitedResume]);
GO

-- Creating foreign key on [StudentCV] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [FK_Students_Resumes]
    FOREIGN KEY ([StudentCV])
    REFERENCES [dbo].[Resumes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Students_Resumes'
CREATE INDEX [IX_FK_Students_Resumes]
ON [dbo].[Students]
    ([StudentCV]);
GO

-- Creating foreign key on [StudentId] in table 'StudentInternships'
ALTER TABLE [dbo].[StudentInternships]
ADD CONSTRAINT [FK_StudentInternship_Students1]
    FOREIGN KEY ([StudentId])
    REFERENCES [dbo].[Students]
        ([StudentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUsers'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUsers]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'UserResumeMapTable'
ALTER TABLE [dbo].[UserResumeMapTable]
ADD CONSTRAINT [FK_UserResumeMapTable_AspNetUsers]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Resumes_Id] in table 'UserResumeMapTable'
ALTER TABLE [dbo].[UserResumeMapTable]
ADD CONSTRAINT [FK_UserResumeMapTable_Resumes]
    FOREIGN KEY ([Resumes_Id])
    REFERENCES [dbo].[Resumes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserResumeMapTable_Resumes'
CREATE INDEX [IX_FK_UserResumeMapTable_Resumes]
ON [dbo].[UserResumeMapTable]
    ([Resumes_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------