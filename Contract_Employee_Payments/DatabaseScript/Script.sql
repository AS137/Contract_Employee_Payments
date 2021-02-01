SET IDENTITY_INSERT [dbo].[ContractEmployee] ON
INSERT INTO [dbo].[ContractEmployee] ([ContractEmployeeId], [Name], [HourlyRate]) VALUES (1, N'Harry Walker', CAST(60.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[ContractEmployee] ([ContractEmployeeId], [Name], [HourlyRate]) VALUES (2, N'Frank Williams', CAST(80.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[ContractEmployee] ([ContractEmployeeId], [Name], [HourlyRate]) VALUES (3, N'George Smith', CAST(75.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[ContractEmployee] OFF
SET IDENTITY_INSERT [dbo].[Project] ON
INSERT INTO [dbo].[Project] ([ProjectId], [ProjectName], [EstimatedHours]) VALUES (1, N'Developer Portal for APIs', 200)
INSERT INTO [dbo].[Project] ([ProjectId], [ProjectName], [EstimatedHours]) VALUES (2, N'E-commerce Advertising API', 300)
INSERT INTO [dbo].[Project] ([ProjectId], [ProjectName], [EstimatedHours]) VALUES (3, N'Digital office ', 450)
SET IDENTITY_INSERT [dbo].[Project] OFF
SET IDENTITY_INSERT [dbo].[TimeRecord] ON
INSERT INTO [dbo].[TimeRecord] ([Id], [ProjectId], [ContractEmployeeId], [StartTime], [EndTime]) VALUES (1, 1, 1, N'2020-12-12 09:00:00', N'2021-02-12 17:00:00')
INSERT INTO [dbo].[TimeRecord] ([Id], [ProjectId], [ContractEmployeeId], [StartTime], [EndTime]) VALUES (2, 3, 3, N'2020-12-14 08:00:00', N'2021-05-14 18:00:00')
SET IDENTITY_INSERT [dbo].[TimeRecord] OFF