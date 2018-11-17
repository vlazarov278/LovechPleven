INSERT INTO travel_cards(card_number, job_during_journey, colonist_id, journey_id)
SELECT CASE
WHEN c.birth_date > '1980-01-01' THEN CONCAT(year(c.birth_date), day(c.birth_date), SUBSTRING(c.ucn, 1, 4))
WHEN c.birth_date <= '1980-01-01' THEN CONCAT(year(c.birth_date), month(c.birth_date), SUBSTRING(c.ucn, 6, 4))
END AS card_number, CASE
WHEN c.id % 2 = 0 THEN "Pilot"
WHEN c.id % 3 = 0 THEN "Cook"
ELSE "Engineer" END AS job_during_journey, c.id AS colonist_id, SUBSTRING(c.ucn, 1, 1) AS journey_id FROM colonists AS c
WHERE c.id BETWEEN 96 AND 100;