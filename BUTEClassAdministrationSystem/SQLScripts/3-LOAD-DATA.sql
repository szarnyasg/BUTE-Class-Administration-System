USE [ClassAdministration]
GO
/****** Object:  Table [dbo].[SemesterSet]    Script Date: 11/18/2012 23:09:04 ******/
SET IDENTITY_INSERT [dbo].[SemesterSet] ON
INSERT [dbo].[SemesterSet] ([Id], [Name]) VALUES (1, N'2011/12/2.')
INSERT [dbo].[SemesterSet] ([Id], [Name]) VALUES (2, N'2012/13/1.')
INSERT [dbo].[SemesterSet] ([Id], [Name]) VALUES (3, N'2012/13/2.')
SET IDENTITY_INSERT [dbo].[SemesterSet] OFF
/****** Object:  Table [dbo].[RoomSet]    Script Date: 11/18/2012 23:09:04 ******/
SET IDENTITY_INSERT [dbo].[RoomSet] ON
INSERT [dbo].[RoomSet] ([Id], [Name], [Computer_count], [Seating_capacity]) VALUES (4, N'QB101', 20, CAST(30 AS Decimal(18, 0)))
INSERT [dbo].[RoomSet] ([Id], [Name], [Computer_count], [Seating_capacity]) VALUES (5, N'QB102', 20, CAST(30 AS Decimal(18, 0)))
INSERT [dbo].[RoomSet] ([Id], [Name], [Computer_count], [Seating_capacity]) VALUES (6, N'QB103', 20, CAST(30 AS Decimal(18, 0)))
INSERT [dbo].[RoomSet] ([Id], [Name], [Computer_count], [Seating_capacity]) VALUES (7, N'QB104', 20, CAST(30 AS Decimal(18, 0)))
INSERT [dbo].[RoomSet] ([Id], [Name], [Computer_count], [Seating_capacity]) VALUES (8, N'IL220', 15, CAST(30 AS Decimal(18, 0)))
INSERT [dbo].[RoomSet] ([Id], [Name], [Computer_count], [Seating_capacity]) VALUES (9, N'IL221', 15, CAST(30 AS Decimal(18, 0)))
INSERT [dbo].[RoomSet] ([Id], [Name], [Computer_count], [Seating_capacity]) VALUES (10, N'IL222', 15, CAST(30 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[RoomSet] OFF
/****** Object:  Table [dbo].[InstructorSet]    Script Date: 11/18/2012 23:09:04 ******/
SET IDENTITY_INSERT [dbo].[InstructorSet] ON
INSERT [dbo].[InstructorSet] ([Id], [Neptun], [Name], [Email]) VALUES (1, N'ABC001', N'Oktató 1', N'oktato1@bme.hu')
INSERT [dbo].[InstructorSet] ([Id], [Neptun], [Name], [Email]) VALUES (2, N'ABC002', N'Oktató 2', N'oktato2@bme.hu')
INSERT [dbo].[InstructorSet] ([Id], [Neptun], [Name], [Email]) VALUES (3, N'ABC003', N'Oktató 3', N'oktato3@bme.hu')
INSERT [dbo].[InstructorSet] ([Id], [Neptun], [Name], [Email]) VALUES (4, N'ABC004', N'Oktató 4', N'oktato4@bme.hu')
INSERT [dbo].[InstructorSet] ([Id], [Neptun], [Name], [Email]) VALUES (5, N'ABC005', N'Oktató 5', N'oktato5@bme.hu')
INSERT [dbo].[InstructorSet] ([Id], [Neptun], [Name], [Email]) VALUES (6, N'ABC006', N'Oktató 6', N'oktato6@bme.hu')
INSERT [dbo].[InstructorSet] ([Id], [Neptun], [Name], [Email]) VALUES (7, N'ABC007', N'Oktató 7', N'oktato7@bme.hu')
INSERT [dbo].[InstructorSet] ([Id], [Neptun], [Name], [Email]) VALUES (8, N'ABC008', N'Oktató 8', N'oktato8@bme.hu')
SET IDENTITY_INSERT [dbo].[InstructorSet] OFF
/****** Object:  Table [dbo].[CourseSet]    Script Date: 11/18/2012 23:24:35 ******/
SET IDENTITY_INSERT [dbo].[CourseSet] ON
INSERT [dbo].[CourseSet] ([Id], [Day_of_week], [Week_parity], [Starting_time], [Semester_Id]) VALUES (1, 1, 1, N'15:00', 1)
INSERT [dbo].[CourseSet] ([Id], [Day_of_week], [Week_parity], [Starting_time], [Semester_Id]) VALUES (2, 1, 1, N'18:00', 1)
INSERT [dbo].[CourseSet] ([Id], [Day_of_week], [Week_parity], [Starting_time], [Semester_Id]) VALUES (3, 1, 0, N'16:00', 1)
INSERT [dbo].[CourseSet] ([Id], [Day_of_week], [Week_parity], [Starting_time], [Semester_Id]) VALUES (4, 4, 0, N'16:00', 2)
INSERT [dbo].[CourseSet] ([Id], [Day_of_week], [Week_parity], [Starting_time], [Semester_Id]) VALUES (5, 5, 0, N'17:00', 2)
SET IDENTITY_INSERT [dbo].[CourseSet] OFF
