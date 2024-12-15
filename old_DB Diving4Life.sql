-- Tworzenie bazy danych
CREATE DATABASE Diving4Life;
GO

USE Diving4Life;
GO

-- Tabela User
CREATE TABLE [User] (
    IdUser INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    PhoneNumber VARCHAR(20) NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL
);

-- Dodawanie rekordów do tabeli User
INSERT INTO [User] (FirstName, LastName, Email, PhoneNumber, PasswordHash)
VALUES 
('Jan', 'Kowalski', 'jan.kowalski@example.com', '123456789', 'hash1'),
('Anna', 'Nowak', 'anna.nowak@example.com', '987654321', 'hash2'),
('Piotr', 'Wiśniewski', 'piotr.wisniewski@example.com', '564738291', 'hash3'),
('Katarzyna', 'Kamińska', 'katarzyna.kaminska@example.com', '112233445', 'hash4'),
('Tomasz', 'Lewandowski', 'tomasz.lewandowski@example.com', '998877665', 'hash5');

-- Tabela EmergencyContacts
CREATE TABLE EmergencyContacts (
    IdEmergencyContact INT IDENTITY(1,1) PRIMARY KEY,
    IdUser INT NOT NULL,
    ContactName VARCHAR(100) NOT NULL,
    Relationship VARCHAR(50) NOT NULL,
    PhoneNumber VARCHAR(20) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    FOREIGN KEY (IdUser) REFERENCES [User](IdUser) ON DELETE CASCADE
);

-- Dodawanie rekordów do tabeli EmergencyContacts
INSERT INTO EmergencyContacts (IdUser, ContactName, Relationship, PhoneNumber, Email)
VALUES
(1, 'Maria Kowalska', 'Żona', '123456780', 'maria.kowalska@example.com'),
(2, 'Tomasz Nowak', 'Brat', '987654322', 'tomasz.nowak@example.com'),
(3, 'Agnieszka Wiśniewska', 'Żona', '564738292', 'agnieszka.wisniewska@example.com'),
(4, 'Adam Kamiński', 'Brat', '112233446', 'adam.kaminski@example.com'),
(5, 'Ewa Lewandowska', 'Siostra', '998877666', 'ewa.lewandowska@example.com');

-- Tabela EquipmentCategories
CREATE TABLE EquipmentCategories (
    IdCategory INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName VARCHAR(50) NOT NULL
);
-- Dodawanie rekordów do tabeli EquipmentCategories
INSERT INTO EquipmentCategories (CategoryName)
VALUES
('Tank'),
('Regulator'),
('Suit'),
('Jacket'),
('Dive Computer'),
('Mask'),
('Fins'),
('Accessories');

-- Tabela EquipmentManufacturer
CREATE TABLE EquipmentManufacturer (
    IdManufacturer INT IDENTITY(1,1) PRIMARY KEY,
    ManufacturerName VARCHAR(100) NOT NULL,
    Country VARCHAR(50) NOT NULL
);

-- Dodawanie rekordów do tabeli EquipmentManufacturer
INSERT INTO EquipmentManufacturer (ManufacturerName, Country)
VALUES
('Aqua Lung', 'USA'),
('Scubapro', 'Switzerland'),
('Mares', 'Italy'),
('Cressi', 'Italy'),
('Beuchat', 'France'),
('Suunto', 'Finland');

-- Tabela Equipment
CREATE TABLE Equipment (
    IdEquipment INT IDENTITY(1,1) PRIMARY KEY,
    IdCategory INT NOT NULL,
    IdManufacturer INT NOT NULL,
    Name VARCHAR(100) NOT NULL,
    SerialNumber VARCHAR(100) UNIQUE NOT NULL,
    PurchaseDate DATE NOT NULL,
    FOREIGN KEY (IdCategory) REFERENCES EquipmentCategories(IdCategory),
    FOREIGN KEY (IdManufacturer) REFERENCES EquipmentManufacturer(IdManufacturer)
);

-- Dodawanie rekordów do tabeli Equipment
INSERT INTO Equipment (IdCategory, IdManufacturer, Name, SerialNumber, PurchaseDate)
VALUES
(1, 1, 'Aqua Lung ADVs', 'A12345', '2023-05-10'),
(1, 2, 'Scubapro MK25', 'S98765', '2022-09-15'),
(1, 3, 'Mares Abyss 22', 'M54321', '2021-03-22'),
(1, 4, 'Cressi Ellipse', 'C11223', '2023-01-30'),
(1, 5, 'Beuchat Master', 'B67890', '2022-06-12'),
(1, 6, 'Suunto EON Core', 'SU22334', '2024-01-05'),
(2, 1, 'Aqua Lung Legend LX', 'A23456', '2023-08-19'),
(2, 2, 'Scubapro G260', 'S87654', '2022-12-05'),
(2, 3, 'Mares Xtreme', 'M33445', '2021-07-14'),
(2, 4, 'Cressi Compact', 'C55667', '2023-03-01'),
(2, 5, 'Beuchat VX', 'B23467', '2022-11-20'),
(2, 6, 'Suunto Vyper 2', 'SU66789', '2023-04-10'),
(3, 1, 'Aqua Lung Quantum', 'A34231', '2022-04-17'),
(3, 2, 'Scubapro Everflex', 'S90876', '2023-07-25'),
(3, 3, 'Mares Flexa', 'M11234', '2021-11-29'),
(3, 4, 'Cressi Tracina', 'C66789', '2022-02-10'),
(3, 5, 'Beuchat 7mm', 'B99321', '2022-08-14'),
(3, 6, 'Suunto D5', 'SU88900', '2023-09-03'),
(4, 1, 'Aqua Lung BCD Pro', 'A23478', '2022-06-20'),
(4, 2, 'Scubapro Hydros Pro', 'S23456', '2021-10-18'),
(4, 3, 'Mares Hybrid', 'M76543', '2023-01-15'),
(4, 4, 'Cressi Start', 'C87901', '2022-05-22'),
(4, 5, 'Beuchat Volo', 'B44321', '2023-11-10'),
(4, 6, 'Suunto Zoop Novo', 'SU11223', '2022-12-05'),
(5, 1, 'Aqua Lung i300c', 'A45567', '2022-09-10'),
(5, 2, 'Scubapro Galileo HUD', 'S87611', '2023-04-20'),
(5, 3, 'Mares Puck Pro', 'M12345', '2023-02-18'),
(5, 4, 'Cressi Leonardo', 'C55332', '2021-11-01'),
(5, 5, 'Beuchat DTD', 'B90876', '2022-07-25');

-- Tabela MaintenanceSchedule
CREATE TABLE MaintenanceSchedule (
    IdMaintenanceSchedule INT IDENTITY(1,1) PRIMARY KEY,
    IdEquipment INT NOT NULL,
    ScheduledDate DATE NOT NULL,
    Description TEXT NOT NULL,
    Status VARCHAR(50) DEFAULT 'Scheduled',
    FOREIGN KEY (IdEquipment) REFERENCES Equipment(IdEquipment) ON DELETE CASCADE
);

-- Dodawanie rekordów do tabeli MaintenanceSchedule
INSERT INTO MaintenanceSchedule (IdEquipment, ScheduledDate, Description, Status)
VALUES
(1, '2024-06-15', 'Regular maintenance check and cleaning', 'Scheduled'),
(2, '2024-05-20', 'Full inspection and service', 'Scheduled'),
(3, '2024-07-01', 'Seal replacement and testing', 'Scheduled'),
(4, '2024-06-22', 'Inspection and leak test', 'Scheduled'),
(5, '2024-06-10', 'Full overhaul and servicing', 'Scheduled'),
(6, '2024-07-05', 'Annual inspection and calibration', 'Scheduled'),
(7, '2024-05-15', 'Cleaning and valve check', 'Scheduled'),
(8, '2024-08-01', 'Pressure check and regulator test', 'Scheduled');

-- Tabela CertificationOrganization
CREATE TABLE CertificationOrganization (
    IdOrganization INT IDENTITY(1,1) PRIMARY KEY,
    OrganizationName VARCHAR(100) NOT NULL,
    Country VARCHAR(50) NOT NULL
);

-- Dodawanie rekordów do tabeli CertificationOrganization
INSERT INTO CertificationOrganization (OrganizationName, Country)
VALUES
('PADI', 'USA'),
('SSI', 'Germany'),
('NAUI', 'USA'),
('CMAS', 'Italy');

-- Tabela TypeOfTraining
CREATE TABLE TypeOfTraining (
    IdTypeOfTraining INT IDENTITY(1,1) PRIMARY KEY,
    TrainingName VARCHAR(100) NOT NULL,
    Description TEXT
);

-- Dodawanie rekordów do tabeli TypeOfTraining
INSERT INTO TypeOfTraining (TrainingName, Description)
VALUES
('Open Water Diver', 'Basic scuba diving course for beginners. Allows diving with a buddy to a depth of 18 meters.'),
('Advanced Open Water Diver', 'Course to enhance diving skills, allowing diving to a depth of 30 meters.'),
('Rescue Diver', 'Course teaching rescue techniques and responding to emergency situations during dives.'),
('Divemaster', 'Course to prepare individuals for a guide role and assistant instructors.'),
('Instructor', 'Scuba instructor course, enabling the teaching of others in diving skills.'),
('Nitrox Diver', 'Course for diving with gas mixtures, allowing safer dives with increased oxygen content.'),
('Wreck Diver', 'Specialized training for divers exploring shipwrecks.'),
('Cave Diver', 'Advanced training for cave diving, including techniques and equipment suited for this environment.'),
('Deep Diver', 'Course that allows diving to greater depths, typically up to 40 meters.'),
('Night Diver', 'Course for diving at night, covering diving techniques and safety in darkness.'),
('Underwater Photographer', 'Training in underwater photography, including techniques for capturing images beneath the surface.'),
('Dry Suit Diver', 'Course for diving in a dry suit, typically used in cold water environments.');

-- Tabela Certificates
CREATE TABLE Certificates (
    IdCertificate INT IDENTITY(1,1) PRIMARY KEY,
    IdUser INT NOT NULL,
    IdOrganization INT NOT NULL,
    IdTypeOfTraining INT NOT NULL,
    IssueDate DATE NOT NULL,
    CertificateNumber VARCHAR(100) UNIQUE NOT NULL,
    FOREIGN KEY (IdUser) REFERENCES [User](IdUser) ON DELETE CASCADE,
    FOREIGN KEY (IdOrganization) REFERENCES CertificationOrganization(IdOrganization),
    FOREIGN KEY (IdTypeOfTraining) REFERENCES TypeOfTraining(IdTypeOfTraining)
);

-- Dodawanie rekordów do tabeli Certificates
INSERT INTO Certificates (IdUser, IdOrganization, IdTypeOfTraining, IssueDate, CertificateNumber)
VALUES
(1, 1, 1, '2023-03-10', 'PADI-12345'), -- Open Water Diver
(1, 2, 2, '2023-06-15', 'SSI-56789'), -- Advanced Open Water Diver
(1, 3, 3, '2023-09-20', 'NAUI-98765'), -- Rescue Diver
(1, 4, 5, '2024-01-12', 'CMAS-54321'), -- Instructor
(2, 1, 1, '2022-11-05', 'PADI-23456'), -- Open Water Diver
(2, 2, 6, '2023-04-30', 'SSI-67890'), -- Nitrox Diver
(2, 3, 7, '2023-08-18', 'NAUI-11223'), -- Wreck Diver
(2, 4, 8, '2024-03-07', 'CMAS-22334'), -- Cave Diver
(3, 1, 2, '2022-10-15', 'PADI-34567'), -- Advanced Open Water Diver
(3, 2, 4, '2023-07-05', 'SSI-78901'), -- Divemaster
(3, 3, 5, '2023-12-02', 'NAUI-65432'), -- Rescue Diver
(3, 4, 9, '2024-02-28', 'CMAS-33221'), -- Deep Diver
(4, 1, 1, '2022-09-10', 'PADI-45678'), -- Open Water Diver
(4, 2, 6, '2023-03-25', 'SSI-89012'), -- Nitrox Diver
(4, 3, 8, '2023-08-09', 'NAUI-12312'), -- Cave Diver
(4, 4, 12, '2024-04-16', 'CMAS-44123'), -- Dry Suit Diver
(5, 1, 3, '2022-12-05', 'PADI-56789'), -- Rescue Diver
(5, 2, 4, '2023-01-20', 'SSI-90123'), -- Divemaster
(5, 3, 7, '2023-05-17', 'NAUI-99887'), -- Wreck Diver
(5, 4, 10, '2024-03-11', 'CMAS-77555'), -- Night Diver
(5, 1, 5, '2023-10-10', 'PADI-67890'); -- Instructor

-- Tabela DiveTypes
CREATE TABLE DiveTypes (
    IdDiveType INT IDENTITY(1,1) PRIMARY KEY,
    TypeName VARCHAR(50) NOT NULL,
    Description TEXT
);

-- Dodawanie rekordów do tabeli DiveTypes
INSERT INTO DiveTypes (TypeName, Description)
VALUES
('Recreational Diving', 'Scuba diving for leisure, exploration, and enjoyment, typically not exceeding depths of 40 meters.'),
('Technical Diving', 'Advanced diving that involves the use of specialized equipment and techniques, such as diving with gas mixtures.'),
('Cave Diving', 'Diving in caves, requiring specialized equipment and techniques due to confined spaces and potential hazards.'),
('Wreck Diving', 'Scuba diving for the exploration and discovery of sunken ships, planes, or other submerged structures.'),
('Night Diving', 'Diving conducted at night, which presents unique challenges like limited visibility and the need for specialized navigation techniques.'),
('Deep Diving', 'Scuba diving to greater depths, usually beyond 40 meters, requiring advanced skills and equipment.'),
('Underwater Photography', 'Diving with the primary goal of taking photographs underwater, which requires proper camera equipment and techniques.'),
('Ice Diving', 'Diving under ice, typically in cold-water environments, with specific equipment and procedures for safety.'),
('Cultural Diving', 'Diving for the purpose of exploring cultural or archaeological sites underwater, such as submerged cities or artifacts.'),
('Safety Diving', 'Training dives to learn and practice emergency procedures and rescue techniques to respond to underwater accidents.'),
('Research Diving', 'Diving conducted for scientific research, such as collecting samples or studying marine ecosystems.'),
('Search and Recovery Diving', 'Diving to locate and recover objects or people underwater, often in rescue or forensic contexts.');

-- Tabela DiveSites
CREATE TABLE DiveSites (
    IdDiveSite INT IDENTITY(1,1) PRIMARY KEY,
    SiteName VARCHAR(100) NOT NULL,
    Location VARCHAR(100) NOT NULL,
    Description TEXT
);

-- Dodawanie rekordów do tabeli DiveSites
INSERT INTO DiveSites (SiteName, Location, Description)
VALUES
('Blue Hole', 'Belize', 'A famous marine sinkhole offering clear waters and diverse marine life, ideal for advanced divers.'),
('Great Barrier Reef', 'Australia', 'The worlds largest coral reef system, known for its rich biodiversity and vibrant underwater ecosystems.'),
('Cenote Dos Ojos', 'Mexico', 'A stunning freshwater cave system offering crystal clear waters and unique underwater formations.'),
('SS Thistlegorm Wreck', 'Egypt', 'A WWII cargo ship wreck located in the Red Sea, home to abundant marine life and historical artifacts.'),
('Palawan Islands', 'Philippines', 'A remote archipelago known for its pristine beaches, clear waters, and diverse marine species.'),
('Raja Ampat', 'Indonesia', 'An isolated paradise with some of the most biodiverse marine ecosystems in the world, perfect for diving.'),
('Sharm El Sheikh', 'Egypt', 'A popular diving destination in the Red Sea, famous for its coral reefs and clear visibility.'),
('Tubbataha Reefs', 'Philippines', 'A UNESCO World Heritage site known for its untouched coral reefs and exceptional underwater biodiversity.'),
('Similan Islands', 'Thailand', 'A group of islands offering some of the best dive sites in the world with vibrant coral reefs and diverse sea life.'),
('Fiji Islands', 'Fiji', 'A world-renowned diving destination with vibrant coral reefs, clear waters, and an abundance of marine life.'),
('Galápagos Islands', 'Ecuador', 'Known for its unique and diverse marine species, including hammerhead sharks, sea lions, and marine iguanas.'),
('Kona Coast', 'Hawaii, USA', 'A volcanic coastline offering clear waters, underwater lava tubes, and abundant marine species.'),
('Cocos Island', 'Costa Rica', 'A remote island with exceptional biodiversity, attracting divers interested in large schools of hammerhead sharks.'),
('Gili Islands', 'Indonesia', 'A popular diving destination with calm waters, excellent coral reefs, and a range of marine life, including turtles.'),
('Andaman Islands', 'India', 'A collection of tropical islands with pristine reefs, crystal-clear waters, and diverse underwater life.');

-- Tabela DiveLogs
CREATE TABLE DiveLogs (
    IdDiveLog INT IDENTITY(1,1) PRIMARY KEY,
    IdUser INT NOT NULL,
    IdDiveType INT NOT NULL,
    IdDiveSite INT NOT NULL,
    DiveDate DATE NOT NULL,
    DiveDuration INT NOT NULL,
    MaxDepth DECIMAL(5,2) NOT NULL,
    FOREIGN KEY (IdUser) REFERENCES [User](IdUser) ON DELETE CASCADE,
    FOREIGN KEY (IdDiveType) REFERENCES DiveTypes(IdDiveType),
    FOREIGN KEY (IdDiveSite) REFERENCES DiveSites(IdDiveSite)
);

-- Dodawanie rekordów do tabeli DiveLogs
INSERT INTO DiveLogs (IdUser, IdDiveType, IdDiveSite, DiveDate, DiveDuration, MaxDepth)
VALUES
(1, 1, 1, '2024-06-01', 40, 30),
(1, 2, 2, '2024-06-10', 55, 40),
(1, 3, 3, '2024-07-01', 50, 25),
(1, 4, 4, '2024-07-15', 60, 35),
(1, 5, 5, '2024-08-01', 70, 45),
(1, 6, 6, '2024-08-20', 65, 30),
(1, 7, 7, '2024-09-05', 80, 50),
(1, 8, 8, '2024-09-20', 75, 40),
(1, 9, 9, '2024-10-01', 45, 25),
(1, 10, 10, '2024-10-10', 50, 30),

(2, 1, 1, '2024-06-02', 45, 30),
(2, 2, 3, '2024-06-12', 50, 30),
(2, 3, 4, '2024-07-03', 55, 35),
(2, 4, 5, '2024-07-18', 60, 40),
(2, 5, 6, '2024-08-03', 65, 45),
(2, 6, 7, '2024-08-22', 50, 30),
(2, 7, 8, '2024-09-10', 70, 50),
(2, 8, 9, '2024-09-25', 75, 55),
(2, 9, 10, '2024-10-05', 40, 25),
(2, 10, 2, '2024-10-15', 60, 40),

(3, 1, 5, '2024-06-05', 35, 25),
(3, 2, 6, '2024-06-18', 50, 35),
(3, 3, 7, '2024-07-08', 60, 45),
(3, 4, 8, '2024-07-22', 55, 30),
(3, 5, 9, '2024-08-07', 70, 40),
(3, 6, 10, '2024-08-25', 80, 50),
(3, 7, 1, '2024-09-02', 65, 45),
(3, 8, 2, '2024-09-18', 75, 50),
(3, 9, 3, '2024-10-01', 50, 30),
(3, 10, 4, '2024-10-12', 45, 20),

(4, 1, 2, '2024-06-06', 50, 30),
(4, 2, 3, '2024-06-20', 60, 35),
(4, 3, 4, '2024-07-02', 45, 25),
(4, 4, 5, '2024-07-17', 70, 45),
(4, 5, 6, '2024-08-05', 65, 40),
(4, 6, 7, '2024-08-21', 80, 50),
(4, 7, 8, '2024-09-07', 75, 45),
(4, 8, 9, '2024-09-22', 60, 35),
(4, 9, 10, '2024-10-03', 50, 30),
(4, 10, 1, '2024-10-13', 55, 40),

(5, 1, 4, '2024-06-07', 45, 25),
(5, 2, 5, '2024-06-23', 55, 35),
(5, 3, 6, '2024-07-04', 60, 40),
(5, 4, 7, '2024-07-19', 65, 45),
(5, 5, 8, '2024-08-10', 70, 50),
(5, 6, 9, '2024-08-30', 75, 50),
(5, 7, 10, '2024-09-03', 80, 55),
(5, 8, 1, '2024-09-14', 65, 40),
(5, 9, 2, '2024-10-07', 60, 35),
(5, 10, 3, '2024-10-20', 50, 30);

-- Tabela DiveConditions
CREATE TABLE DiveConditions (
    IdCondition INT IDENTITY(1,1) PRIMARY KEY,
    IdDiveLog INT NOT NULL,
    Temperature DECIMAL(4,1) NOT NULL,
    WaterCurrent VARCHAR(50) NOT NULL,
    Visibility VARCHAR(50) NOT NULL,
    Notes TEXT,
    FOREIGN KEY (IdDiveLog) REFERENCES DiveLogs(IdDiveLog) ON DELETE CASCADE
);

-- Dodawanie rekordów do tabeli DiveConditions (kontynuacja)
INSERT INTO DiveConditions (IdDiveLog, Temperature, WaterCurrent, Visibility, Notes)
VALUES
(1, 24.5, 'Moderate', 'Good', 'Clear waters with slight current'),
(2, 22.0, 'Strong', 'Fair', 'Strong current made the dive challenging'),
(3, 26.3, 'Weak', 'Excellent', 'Perfect conditions for a long dive'),
(4, 20.0, 'None', 'Good', 'Calm seas, great visibility'),
(5, 21.5, 'Moderate', 'Good', 'Some current, but visibility remained good'),
(6, 23.0, 'Strong', 'Fair', 'Challenging visibility due to strong current'),
(7, 25.1, 'Weak', 'Excellent', 'Clear water, perfect diving conditions'),
(8, 22.3, 'None', 'Good', 'Clear water with minimal current'),
(9, 23.0, 'Weak', 'Excellent', 'Perfect visibility and calm seas'),
(10, 24.5, 'Moderate', 'Good', 'Slight current, visibility was good'),
(11, 21.0, 'Strong', 'Fair', 'Visibility was reduced due to strong current'),
(12, 25.2, 'None', 'Excellent', 'Perfect conditions, calm water, good visibility'),
(13, 22.1, 'Weak', 'Good', 'Slight current, good visibility'),
(14, 26.0, 'Moderate', 'Fair', 'Visibility affected by slight murkiness in water'),
(15, 24.0, 'Strong', 'Good', 'Strong current made diving difficult'),
(16, 23.8, 'None', 'Good', 'Calm water, great visibility'),
(17, 22.9, 'Moderate', 'Fair', 'Visibility affected by the current'),
(18, 25.5, 'Weak', 'Excellent', 'Clear water with perfect conditions for diving'),
(19, 23.3, 'Strong', 'Fair', 'Strong current made diving challenging'),
(20, 24.7, 'None', 'Excellent', 'Perfect dive conditions with great visibility'),
(21, 20.4, 'Weak', 'Good', 'Mild current, good visibility'),
(22, 23.0, 'Strong', 'Fair', 'Strong current with limited visibility'),
(23, 24.9, 'None', 'Good', 'Great diving conditions with calm water'),
(24, 22.7, 'Moderate', 'Excellent', 'Visibility was great despite moderate current'),
(25, 21.5, 'None', 'Good', 'Clear waters with calm conditions'),
(26, 20.0, 'Weak', 'Fair', 'Mild current with some reduction in visibility'),
(27, 22.5, 'Strong', 'Good', 'Struggled with strong current but visibility was good'),
(28, 23.2, 'None', 'Excellent', 'Perfect visibility and calm waters'),
(29, 24.3, 'Moderate', 'Fair', 'Good conditions but some visibility loss due to current'),
(30, 25.0, 'Weak', 'Good', 'Clear water and good visibility with light current'),
(31, 23.5, 'Strong', 'Fair', 'Limited visibility due to strong current'),
(32, 21.3, 'None', 'Good', 'Calm water, good visibility'),
(33, 22.8, 'Moderate', 'Good', 'Slight current, decent visibility'),
(34, 23.7, 'Weak', 'Excellent', 'Perfect visibility with minimal current'),
(35, 21.0, 'Strong', 'Fair', 'Limited visibility due to strong current'),
(36, 24.0, 'None', 'Excellent', 'Great visibility and calm conditions'),
(37, 20.8, 'Weak', 'Good', 'Mild current but good visibility'),
(38, 25.2, 'Moderate', 'Fair', 'Strong current reduced visibility slightly'),
(39, 22.1, 'None', 'Good', 'Clear water with good visibility'),
(40, 23.0, 'Weak', 'Excellent', 'Good conditions with slight current'),
(41, 24.5, 'Moderate', 'Fair', 'Good visibility despite moderate current'),
(42, 23.5, 'Strong', 'Fair', 'Visibility reduced but still decent due to current'),
(43, 21.2, 'None', 'Good', 'Calm water with good visibility'),
(44, 22.4, 'Weak', 'Excellent', 'Perfect conditions with slight current'),
(45, 24.6, 'Strong', 'Fair', 'Challenging current with average visibility'),
(46, 23.8, 'Moderate', 'Good', 'Moderate current, decent visibility'),
(47, 25.1, 'Weak', 'Excellent', 'Great visibility and calm waters'),
(48, 22.9, 'None', 'Good', 'Calm and clear water'),
(49, 24.2, 'Moderate', 'Good', 'Visibility was good despite moderate current'),
(50, 23.6, 'Strong', 'Fair', 'Strong current with limited visibility');

-- Tabela DiveStatistic
CREATE TABLE DiveStatistic (
    IdStatistic INT IDENTITY(1,1) PRIMARY KEY,
    IdDiveLog INT NOT NULL,
    AirConsumed DECIMAL(10,2) NOT NULL,
    AscentRate DECIMAL(5,2) NOT NULL,
    BottomTime INT NOT NULL,
    FOREIGN KEY (IdDiveLog) REFERENCES DiveLogs(IdDiveLog) ON DELETE CASCADE
);

-- Dodawanie rekordów do tabeli DiveStatistic
INSERT INTO DiveStatistic (IdDiveLog, AirConsumed, AscentRate, BottomTime)
VALUES
(1, 200.5, 5.2, 35),
(2, 180.4, 4.8, 40),
(3, 210.3, 6.0, 45),
(4, 195.0, 4.5, 50),
(5, 205.2, 5.1, 33),
(6, 215.4, 5.5, 38),
(7, 220.1, 5.3, 42),
(8, 185.0, 4.9, 37),
(9, 230.0, 5.0, 43),
(10, 195.3, 5.4, 44),
(11, 201.1, 5.0, 39),
(12, 205.7, 5.6, 41),
(13, 198.3, 5.1, 36),
(14, 210.0, 4.7, 46),
(15, 220.5, 5.4, 40),
(16, 225.6, 5.2, 32),
(17, 230.2, 4.8, 41),
(18, 240.1, 5.7, 45),
(19, 215.4, 5.0, 42),
(20, 210.3, 5.6, 47),
(21, 230.5, 5.3, 48),
(22, 195.6, 4.9, 44),
(23, 185.1, 4.8, 39),
(24, 215.8, 5.5, 50),
(25, 225.3, 5.0, 49),
(26, 205.4, 4.7, 45),
(27, 200.1, 5.2, 36),
(28, 195.3, 5.0, 42),
(29, 205.5, 5.1, 38),
(30, 210.4, 5.6, 47),
(31, 220.2, 5.3, 41),
(32, 225.0, 5.5, 43),
(33, 240.0, 4.9, 40),
(34, 205.0, 5.4, 34),
(35, 215.2, 5.3, 39),
(36, 225.7, 5.6, 46),
(37, 230.4, 5.2, 44),
(38, 210.5, 5.0, 42),
(39, 220.3, 4.8, 41),
(40, 225.1, 5.2, 38),
(41, 235.0, 5.6, 47),
(42, 240.3, 5.5, 39),
(43, 215.1, 5.4, 45),
(44, 210.2, 5.3, 43),
(45, 200.0, 5.1, 41),
(46, 195.7, 5.5, 48),
(47, 220.1, 5.0, 40),
(48, 225.2, 5.2, 49),
(49, 230.1, 5.4, 42),
(50, 235.3, 5.6, 45);


-- Tabela BuddySystem
CREATE TABLE BuddySystem (
    IdBuddy INT IDENTITY(1,1) PRIMARY KEY,
    IdDiveLog INT NOT NULL,
    BuddyName VARCHAR(100) NOT NULL,
    CertificationLevel VARCHAR(50) NOT NULL,
    ContactDetails VARCHAR(100) NOT NULL,
    FOREIGN KEY (IdDiveLog) REFERENCES DiveLogs(IdDiveLog) ON DELETE CASCADE
);

-- Dodawanie rekordów do tabeli BuddySystem
INSERT INTO BuddySystem (IdDiveLog, BuddyName, CertificationLevel, ContactDetails)
VALUES
(1, 'Jan Kowalski', 'Advanced Open Water', 'jan.kowalski@example.com'),
(2, 'Anna Nowak', 'Open Water', 'anna.nowak@example.com'),
(3, 'Piotr Zieliński', 'Rescue Diver', 'piotr.zielinski@example.com'),
(4, 'Katarzyna Wójcik', 'Advanced Open Water', 'katarzyna.wojcik@example.com'),
(5, 'Tomasz Kaczmarek', 'Open Water', 'tomasz.kaczmarek@example.com'),
(6, 'Jan Kowalski', 'Rescue Diver', 'jan.kowalski@example.com'),
(7, 'Anna Nowak', 'Advanced Open Water', 'anna.nowak@example.com'),
(8, 'Piotr Zieliński', 'Open Water', 'piotr.zielinski@example.com'),
(9, 'Katarzyna Wójcik', 'Rescue Diver', 'katarzyna.wojcik@example.com'),
(10, 'Tomasz Kaczmarek', 'Advanced Open Water', 'tomasz.kaczmarek@example.com'),
(11, 'Jan Kowalski', 'Open Water', 'jan.kowalski@example.com'),
(12, 'Anna Nowak', 'Rescue Diver', 'anna.nowak@example.com'),
(13, 'Piotr Zieliński', 'Advanced Open Water', 'piotr.zielinski@example.com'),
(14, 'Katarzyna Wójcik', 'Open Water', 'katarzyna.wojcik@example.com'),
(15, 'Tomasz Kaczmarek', 'Rescue Diver', 'tomasz.kaczmarek@example.com'),
(16, 'Jan Kowalski', 'Advanced Open Water', 'jan.kowalski@example.com'),
(17, 'Anna Nowak', 'Open Water', 'anna.nowak@example.com'),
(18, 'Piotr Zieliński', 'Rescue Diver', 'piotr.zielinski@example.com'),
(19, 'Katarzyna Wójcik', 'Advanced Open Water', 'katarzyna.wojcik@example.com'),
(20, 'Tomasz Kaczmarek', 'Open Water', 'tomasz.kaczmarek@example.com'),
(21, 'Jan Kowalski', 'Rescue Diver', 'jan.kowalski@example.com'),
(22, 'Anna Nowak', 'Advanced Open Water', 'anna.nowak@example.com'),
(23, 'Piotr Zieliński', 'Open Water', 'piotr.zielinski@example.com'),
(24, 'Katarzyna Wójcik', 'Rescue Diver', 'katarzyna.wojcik@example.com'),
(25, 'Tomasz Kaczmarek', 'Advanced Open Water', 'tomasz.kaczmarek@example.com'),
(26, 'Jan Kowalski', 'Open Water', 'jan.kowalski@example.com'),
(27, 'Anna Nowak', 'Rescue Diver', 'anna.nowak@example.com'),
(28, 'Piotr Zieliński', 'Advanced Open Water', 'piotr.zielinski@example.com'),
(29, 'Katarzyna Wójcik', 'Open Water', 'katarzyna.wojcik@example.com'),
(30, 'Tomasz Kaczmarek', 'Rescue Diver', 'tomasz.kaczmarek@example.com'),
(31, 'Jan Kowalski', 'Advanced Open Water', 'jan.kowalski@example.com'),
(32, 'Anna Nowak', 'Open Water', 'anna.nowak@example.com'),
(33, 'Piotr Zieliński', 'Rescue Diver', 'piotr.zielinski@example.com'),
(34, 'Katarzyna Wójcik', 'Advanced Open Water', 'katarzyna.wojcik@example.com'),
(35, 'Tomasz Kaczmarek', 'Open Water', 'tomasz.kaczmarek@example.com'),
(36, 'Jan Kowalski', 'Rescue Diver', 'jan.kowalski@example.com'),
(37, 'Anna Nowak', 'Advanced Open Water', 'anna.nowak@example.com'),
(38, 'Piotr Zieliński', 'Open Water', 'piotr.zielinski@example.com'),
(39, 'Katarzyna Wójcik', 'Rescue Diver', 'katarzyna.wojcik@example.com'),
(40, 'Tomasz Kaczmarek', 'Advanced Open Water', 'tomasz.kaczmarek@example.com'),
(41, 'Jan Kowalski', 'Open Water', 'jan.kowalski@example.com'),
(42, 'Anna Nowak', 'Rescue Diver', 'anna.nowak@example.com'),
(43, 'Piotr Zieliński', 'Advanced Open Water', 'piotr.zielinski@example.com'),
(44, 'Katarzyna Wójcik', 'Open Water', 'katarzyna.wojcik@example.com'),
(45, 'Tomasz Kaczmarek', 'Rescue Diver', 'tomasz.kaczmarek@example.com'),
(46, 'Jan Kowalski', 'Advanced Open Water', 'jan.kowalski@example.com'),
(47, 'Anna Nowak', 'Open Water', 'anna.nowak@example.com'),
(48, 'Piotr Zieliński', 'Rescue Diver', 'piotr.zielinski@example.com'),
(49, 'Katarzyna Wójcik', 'Advanced Open Water', 'katarzyna.wojcik@example.com'),
(50, 'Tomasz Kaczmarek', 'Open Water', 'tomasz.kaczmarek@example.com');
