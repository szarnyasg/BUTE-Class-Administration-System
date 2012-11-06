
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/06/2012 20:07:32
-- Generated from EDMX file: C:\GitHub\BUTE-Class-Administration-System\BUTEClassAdministrationSystem\BUTEClassAdministrationModel\ClassAdministrationDatabase.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ClassAdministration];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_StudentCourse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentSet] DROP CONSTRAINT [FK_StudentCourse];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupInstructor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupSet] DROP CONSTRAINT [FK_GroupInstructor];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupSet] DROP CONSTRAINT [FK_CourseGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_RoomCourse_Room]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoomCourse] DROP CONSTRAINT [FK_RoomCourse_Room];
GO
IF OBJECT_ID(N'[dbo].[FK_RoomCourse_Course]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoomCourse] DROP CONSTRAINT [FK_RoomCourse_Course];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupRoom]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupSet] DROP CONSTRAINT [FK_GroupRoom];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupStudent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentSet] DROP CONSTRAINT [FK_GroupStudent];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[StudentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentSet];
GO
IF OBJECT_ID(N'[dbo].[RoomSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoomSet];
GO
IF OBJECT_ID(N'[dbo].[InstructorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InstructorSet];
GO
IF OBJECT_ID(N'[dbo].[GroupSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupSet];
GO
IF OBJECT_ID(N'[dbo].[CourseSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourseSet];
GO
IF OBJECT_ID(N'[dbo].[RoomCourse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoomCourse];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'StudentSet'
CREATE TABLE [dbo].[StudentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Neptun] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Course_Id] int  NULL,
    [Group_Id] int  NULL,
    [Semester_Id] int  NOT NULL
);
GO

-- Creating table 'RoomSet'
CREATE TABLE [dbo].[RoomSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Computer_count] int  NOT NULL,
    [Seating_capacity] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'InstructorSet'
CREATE TABLE [dbo].[InstructorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Neptun] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'GroupSet'
CREATE TABLE [dbo].[GroupSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Index] decimal(18,0)  NOT NULL,
    [Instructor_Id] int  NOT NULL,
    [Course_Id] int  NOT NULL,
    [Room_Id] int  NOT NULL,
    [Semester_Id] int  NOT NULL
);
GO

-- Creating table 'CourseSet'
CREATE TABLE [dbo].[CourseSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Day_of_week] decimal(18,0)  NOT NULL,
    [Week_parity] bit  NOT NULL,
    [Starting_time] time  NOT NULL,
    [Semester_Id] int  NOT NULL
);
GO

-- Creating table 'SemesterSet'
CREATE TABLE [dbo].[SemesterSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Semester_name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RoomCourse'
CREATE TABLE [dbo].[RoomCourse] (
    [Room_Id] int  NOT NULL,
    [Course_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'StudentSet'
ALTER TABLE [dbo].[StudentSet]
ADD CONSTRAINT [PK_StudentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RoomSet'
ALTER TABLE [dbo].[RoomSet]
ADD CONSTRAINT [PK_RoomSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InstructorSet'
ALTER TABLE [dbo].[InstructorSet]
ADD CONSTRAINT [PK_InstructorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GroupSet'
ALTER TABLE [dbo].[GroupSet]
ADD CONSTRAINT [PK_GroupSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CourseSet'
ALTER TABLE [dbo].[CourseSet]
ADD CONSTRAINT [PK_CourseSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SemesterSet'
ALTER TABLE [dbo].[SemesterSet]
ADD CONSTRAINT [PK_SemesterSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Room_Id], [Course_Id] in table 'RoomCourse'
ALTER TABLE [dbo].[RoomCourse]
ADD CONSTRAINT [PK_RoomCourse]
    PRIMARY KEY NONCLUSTERED ([Room_Id], [Course_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Course_Id] in table 'StudentSet'
ALTER TABLE [dbo].[StudentSet]
ADD CONSTRAINT [FK_StudentCourse]
    FOREIGN KEY ([Course_Id])
    REFERENCES [dbo].[CourseSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentCourse'
CREATE INDEX [IX_FK_StudentCourse]
ON [dbo].[StudentSet]
    ([Course_Id]);
GO

-- Creating foreign key on [Instructor_Id] in table 'GroupSet'
ALTER TABLE [dbo].[GroupSet]
ADD CONSTRAINT [FK_GroupInstructor]
    FOREIGN KEY ([Instructor_Id])
    REFERENCES [dbo].[InstructorSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupInstructor'
CREATE INDEX [IX_FK_GroupInstructor]
ON [dbo].[GroupSet]
    ([Instructor_Id]);
GO

-- Creating foreign key on [Course_Id] in table 'GroupSet'
ALTER TABLE [dbo].[GroupSet]
ADD CONSTRAINT [FK_CourseGroup]
    FOREIGN KEY ([Course_Id])
    REFERENCES [dbo].[CourseSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseGroup'
CREATE INDEX [IX_FK_CourseGroup]
ON [dbo].[GroupSet]
    ([Course_Id]);
GO

-- Creating foreign key on [Room_Id] in table 'RoomCourse'
ALTER TABLE [dbo].[RoomCourse]
ADD CONSTRAINT [FK_RoomCourse_Room]
    FOREIGN KEY ([Room_Id])
    REFERENCES [dbo].[RoomSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Course_Id] in table 'RoomCourse'
ALTER TABLE [dbo].[RoomCourse]
ADD CONSTRAINT [FK_RoomCourse_Course]
    FOREIGN KEY ([Course_Id])
    REFERENCES [dbo].[CourseSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoomCourse_Course'
CREATE INDEX [IX_FK_RoomCourse_Course]
ON [dbo].[RoomCourse]
    ([Course_Id]);
GO

-- Creating foreign key on [Room_Id] in table 'GroupSet'
ALTER TABLE [dbo].[GroupSet]
ADD CONSTRAINT [FK_GroupRoom]
    FOREIGN KEY ([Room_Id])
    REFERENCES [dbo].[RoomSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupRoom'
CREATE INDEX [IX_FK_GroupRoom]
ON [dbo].[GroupSet]
    ([Room_Id]);
GO

-- Creating foreign key on [Group_Id] in table 'StudentSet'
ALTER TABLE [dbo].[StudentSet]
ADD CONSTRAINT [FK_GroupStudent]
    FOREIGN KEY ([Group_Id])
    REFERENCES [dbo].[GroupSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupStudent'
CREATE INDEX [IX_FK_GroupStudent]
ON [dbo].[StudentSet]
    ([Group_Id]);
GO

-- Creating foreign key on [Semester_Id] in table 'GroupSet'
ALTER TABLE [dbo].[GroupSet]
ADD CONSTRAINT [FK_SemesterGroup]
    FOREIGN KEY ([Semester_Id])
    REFERENCES [dbo].[SemesterSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SemesterGroup'
CREATE INDEX [IX_FK_SemesterGroup]
ON [dbo].[GroupSet]
    ([Semester_Id]);
GO

-- Creating foreign key on [Semester_Id] in table 'StudentSet'
ALTER TABLE [dbo].[StudentSet]
ADD CONSTRAINT [FK_SemesterStudent]
    FOREIGN KEY ([Semester_Id])
    REFERENCES [dbo].[SemesterSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SemesterStudent'
CREATE INDEX [IX_FK_SemesterStudent]
ON [dbo].[StudentSet]
    ([Semester_Id]);
GO

-- Creating foreign key on [Semester_Id] in table 'CourseSet'
ALTER TABLE [dbo].[CourseSet]
ADD CONSTRAINT [FK_SemesterCourse]
    FOREIGN KEY ([Semester_Id])
    REFERENCES [dbo].[SemesterSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SemesterCourse'
CREATE INDEX [IX_FK_SemesterCourse]
ON [dbo].[CourseSet]
    ([Semester_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------