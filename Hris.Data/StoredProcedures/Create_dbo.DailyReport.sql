USE [HRISDb]
GO

/****** Object: SqlProcedure [dbo].[DailyReport] Script Date: 6/4/2023 2:48:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DailyReport]
	@Start_Date datetime,
    @End_Date datetime
AS
	SELECT Tracks.Start AS TrackStart, Client.Name AS ClientName, Projects.Name AS ProjectName, Tasks.Name AS TaskName, DATEDIFF(second, Tracks.Start, COALESCE([dbo].[Tracks].[End], GETDATE())) AS TotalSeconds FROM [dbo].[Client] 
	JOIN [dbo].[Projects] ON Client.Id = Projects.ClientId
	JOIN [dbo].[Tracks] ON Tracks.ProjectId = Projects.Id
	JOIN [dbo].[Tasks] ON Tasks.Id = Tracks.TaskId
	WHERE [dbo].[Tracks].[End] IS NOT NULL 
		AND [dbo].[Tracks].[ParentTrackId] IS NULL 
		AND [dbo].[Tracks].[Start] >= @Start_Date 
		AND [dbo].[Tracks].[End] <= @End_Date
	ORDER BY [dbo].[Tracks].[Start] DESC
RETURN 0
