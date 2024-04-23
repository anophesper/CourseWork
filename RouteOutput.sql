SELECT 
    r.ID as 'ID маршруту',
    o.City as 'Пункт відправки',
    GROUP_CONCAT(DISTINCT b.City ORDER BY rb.BranchID SEPARATOR ', ') as 'Проміжні відділення',
    d.City as 'Пункт призначення'
FROM 
    Route r
JOIN 
    Branch o ON r.Origin = o.ID
JOIN 
    Branch d ON r.Destination = d.ID
LEFT JOIN 
    Route_Branch rb ON r.ID = rb.RouteID
LEFT JOIN 
    Branch b ON rb.BranchID = b.ID
GROUP BY 
    r.ID;
