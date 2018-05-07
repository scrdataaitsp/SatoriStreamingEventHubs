WITH firstRows AS
(
SELECT 
    header.[user-data] AS 'provider',
    System.Timestamp AS 'datetime',
    GetArrayElement(entity, 0) firstRow
FROM
    <eventhub_input> TIMESTAMP BY DATEADD(second, header.timestamp, '1970-01-01T00:00:00Z') 
)

SELECT
    provider,
    [datetime],
    firstRow.vehicle.trip.trip_id AS 'trip_id',
    firstRow.vehicle.trip.route_id AS 'route_id',
    firstRow.vehicle.trip.start_date AS 'startdatestring',
    firstRow.vehicle.trip.schedule_relationship AS 'schedule_relationship',
    firstRow.vehicle.vehicle.id AS 'vehicle_id',
    firstRow.vehicle.label AS 'vehicle',
    firstRow.vehicle.position.latitude AS 'latitude',
    firstRow.vehicle.position.longitude AS 'longitude',
    firstRow.vehicle.position.bearing AS 'bearing',
    firstRow.vehicle.position.odometer AS 'odometer',
    firstRow.vehicle.position.speed AS 'speed',
    firstRow.vehicle.current_stop_sequence AS 'current_stop',
    firstRow.vehicle.current_status AS 'current_status',
    firstRow.vehicle.timestamp AS 'timestampstring',
    firstRow.vehicle.congestion_level AS 'congestion_level',
    60 AS 'max_speed',
    1 AS 'count'
into <power_bi_output>
FROM firstRows


