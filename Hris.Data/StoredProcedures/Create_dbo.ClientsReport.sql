USE [HRISDb]
GO

/****** Object: SqlProcedure [dbo].[ClientsReport] Script Date: 6/4/2023 2:48:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO











CREATE PROCEDURE [dbo].[ClientsReport]
	@Start_Date datetime,
    @End_Date datetime,
	@Client_Ids NVARCHAR(1000),
	@Project_Ids NVARCHAR(1000),
	@Task_Ids NVARCHAR(1000)
AS
	SELECT Tracks.Start AS TrackStart, COALESCE(Client.Name, 'Others') AS ClientName, Projects.Name AS ProjectName, COALESCE(Tasks.Name, 'Others') AS TaskName, DATEDIFF(second, Tracks.Start, COALESCE([dbo].[Tracks].[End], GETDATE())) AS TotalSeconds 
	FROM [dbo].[Tracks]
		LEFT JOIN [dbo].[Projects] ON Projects.Id = Tracks.ProjectId
		LEFT JOIN [dbo].[Client] ON Client.Id = Projects.ClientId
		LEFT JOIN [dbo].[Tasks] ON Tasks.Id = Tracks.TaskId
	WHERE [dbo].[Tracks].[End] IS NOT NULL 
		AND [dbo].[Tracks].[ParentTrackId] IS NULL 
		AND [dbo].[Tracks].[Start] >= @Start_Date 
		AND [dbo].[Tracks].[End] <= @End_Date
		AND (@Client_Ids != '' AND [dbo].[Projects].[ClientId] IN (SELECT VALUE FROM STRING_SPLIT(@Client_Ids, ',')) OR (@Client_Ids = '' AND ([dbo].[Projects].[ClientId] IS NOT NULL OR [dbo].[Projects].[ClientId] IS NULL)))
		AND (@Project_Ids != '' AND [dbo].[Tracks].[ProjectId] IN (SELECT VALUE FROM STRING_SPLIT(@Project_Ids, ',')) OR (@Project_Ids = '' AND ([dbo].[Tracks].[ProjectId] IS NOT NULL OR [dbo].[Tracks].[ProjectId] IS NULL)))
		AND (@Task_Ids != '' AND [dbo].[Tracks].[TaskId] IN (SELECT VALUE FROM STRING_SPLIT(@Task_Ids, ',')) OR (@Task_Ids = '' AND ([dbo].[Tracks].[TaskId] IS NOT NULL OR [dbo].[Tracks].[TaskId] IS NULL)))
