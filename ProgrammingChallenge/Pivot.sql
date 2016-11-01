drop table #Ticket
drop table #StatusChange

CREATE TABLE #Ticket
(
Id int,
Summary varchar(15),
UserFullName varchar(30)
)
INSERT INTO #Ticket values (1, 's1', 'u1')
INSERT INTO #Ticket values (2, 's2', 'u2')
INSERT INTO #Ticket values (3, 's3', 'u3')
INSERT INTO #Ticket values (4, 's4', 'u4')

CREATE TABLE #StatusChange
(
TicketId int,
Timestamp datetime,
OldStatus varchar(30),
NewStatus varchar(30)
)

INSERT INTO #StatusChange values (1, '2014-01-01 00:00', null, 'New')
INSERT INTO #StatusChange values (1, '2014-01-01 01:15', 'New', 'In Progress')
INSERT INTO #StatusChange values (2, '2014-01-01 02:32', null, 'New')
INSERT INTO #StatusChange values (3, '2014-01-01 04:53', null, 'New')

INSERT INTO #StatusChange values (2, '2014-01-01 05:07', 'New', 'In Progress')
INSERT INTO #StatusChange values (2, '2014-01-01 06:14', 'In Progress', 'Closed')

INSERT INTO #StatusChange values (4, '2014-01-01 07:22', null, 'New')
INSERT INTO #StatusChange values (1, '2014-01-01 08:25', 'In Progress', 'Closed')

INSERT INTO #StatusChange values (2, '2014-01-01 09:32', 'Closed', 'Reopened')
INSERT INTO #StatusChange values (3, '2014-01-01 10:55', 'New', 'In Progress')
INSERT INTO #StatusChange values (4, '2014-01-01 11:05', 'New', 'Closed')

SELECT Id, Summary, [New], [In Progress], [Closed], [Reopened]
FROM 
(
	SELECT Id, Summary, MinInQueue, NewStatus
	FROM #Ticket t (NOLOCK)
	INNER JOIN (
		SELECT s1.ticketId, DATEDIFF(n, s1.Timestamp, COALESCE(s2.Timestamp, '2014-01-01 12:00')) as MinInQueue, s1.NewStatus
		FROM #StatusChange s1 (NOLOCK)
		LEFT JOIN #StatusChange s2
			ON s1.TicketId = S2.TicketId AND s1.NewStatus = s2.OldStatus
	) as s
	ON t.Id = s.TicketId
) as a
PIVOT 
(
	Sum(MinInQueue)
	FOR NewStatus
	IN ([New],[In Progress],[Closed],[Reopened])
) 
AS p



SELECT Id, Summary, MinInQueue, NewStatus
FROM #Ticket t (NOLOCK)
INNER JOIN (
	SELECT s1.ticketId, DATEDIFF(n, s1.Timestamp, COALESCE(s2.Timestamp, '2014-01-01 12:00')) as MinInQueue, s1.NewStatus
	FROM #StatusChange s1 (NOLOCK)
	LEFT JOIN #StatusChange s2
		ON s1.TicketId = S2.TicketId AND s1.NewStatus = s2.OldStatus	
) AS s 
	ON s.TicketId = t.Id
