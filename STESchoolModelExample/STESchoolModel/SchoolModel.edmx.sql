
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/02/2012 18:07:17
-- Generated from EDMX file: C:\temp\STESchoolModelExample\STESchoolModelExample\STESchoolModel\SchoolModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [master];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Course_Department]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Course] DROP CONSTRAINT [FK_Course_Department];
GO
IF OBJECT_ID(N'[dbo].[FK_OnlineCourse_Course]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OnlineCourse] DROP CONSTRAINT [FK_OnlineCourse_Course];
GO
IF OBJECT_ID(N'[dbo].[FK_OnsiteCourse_Course]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OnsiteCourse] DROP CONSTRAINT [FK_OnsiteCourse_Course];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Course]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Course];
GO
IF OBJECT_ID(N'[dbo].[Department]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Department];
GO
IF OBJECT_ID(N'[dbo].[OnlineCourse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OnlineCourse];
GO
IF OBJECT_ID(N'[dbo].[OnsiteCourse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OnsiteCourse];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Courses'
CREATE TABLE [dbo].[Courses] (
    [CourseID] int  NOT NULL,
    [Title] nvarchar(100)  NOT NULL,
    [Credits] int  NOT NULL,
    [DepartmentID] int  NOT NULL
);
GO

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [DepartmentID] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Budget] decimal(19,4)  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [Administrator] int  NULL
);
GO

-- Creating table 'Courses_OnlineCourse'
CREATE TABLE [dbo].[Courses_OnlineCourse] (
    [URL] nvarchar(100)  NOT NULL,
    [CourseID] int  NOT NULL
);
GO

-- Creating table 'Courses_OnsiteCourse'
CREATE TABLE [dbo].[Courses_OnsiteCourse] (
    [Location] nvarchar(50)  NOT NULL,
    [Days] nvarchar(50)  NOT NULL,
    [Time] datetime  NOT NULL,
    [CourseID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CourseID] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [PK_Courses]
    PRIMARY KEY CLUSTERED ([CourseID] ASC);
GO

-- Creating primary key on [DepartmentID] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([DepartmentID] ASC);
GO

-- Creating primary key on [CourseID] in table 'Courses_OnlineCourse'
ALTER TABLE [dbo].[Courses_OnlineCourse]
ADD CONSTRAINT [PK_Courses_OnlineCourse]
    PRIMARY KEY CLUSTERED ([CourseID] ASC);
GO

-- Creating primary key on [CourseID] in table 'Courses_OnsiteCourse'
ALTER TABLE [dbo].[Courses_OnsiteCourse]
ADD CONSTRAINT [PK_Courses_OnsiteCourse]
    PRIMARY KEY CLUSTERED ([CourseID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [DepartmentID] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [FK_Course_Department]
    FOREIGN KEY ([DepartmentID])
    REFERENCES [dbo].[Departments]
        ([DepartmentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Course_Department'
CREATE INDEX [IX_FK_Course_Department]
ON [dbo].[Courses]
    ([DepartmentID]);
GO

-- Creating foreign key on [CourseID] in table 'Courses_OnlineCourse'
ALTER TABLE [dbo].[Courses_OnlineCourse]
ADD CONSTRAINT [FK_OnlineCourse_inherits_Course]
    FOREIGN KEY ([CourseID])
    REFERENCES [dbo].[Courses]
        ([CourseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [CourseID] in table 'Courses_OnsiteCourse'
ALTER TABLE [dbo].[Courses_OnsiteCourse]
ADD CONSTRAINT [FK_OnsiteCourse_inherits_Course]
    FOREIGN KEY ([CourseID])
    REFERENCES [dbo].[Courses]
        ([CourseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------