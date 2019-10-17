USE projectcodeworks;
CREATE TABLE burgers
 (
    id VARCHAR(255) NOT NULL,
    name VARCHAR(255) NOT NULL,
    description VARCHAR(255) NOT NULL,
     price decimal(5,2) DEFAULT .99,

   PRIMARY KEY(id)
 );

-- CREATE
-- INSERT INTO burgers 
-- (id, name, price, description)
-- VALUES
-- ("567", "D$", 12.91, "some of the meat and cheese we have");

-- GET ALL
-- SELECT * FROM burgers;

-- GET BY (Find)
-- SELECT * FROM burgers WHERE id = 235;


-- EDIT
-- UPDATE burgers
-- SET name = "Aloha Zach"
-- WHERE id = 235;

-- REMOVE by
-- DELETE FROM burgers WHERE id = 235;

