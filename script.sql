INSERT INTO illnesses(nom) VALUES('Common Cold');
INSERT INTO illnesses(nom) VALUES('Flu');
INSERT INTO illnesses(nom) VALUES('Strep Throat');
INSERT INTO illnesses(nom) VALUES('Gastronenteritis');
INSERT INTO illnesses(nom) VALUES('Common Headache');
INSERT INTO illnesses(nom) VALUES('Fatigue');
INSERT INTO illnesses(nom) VALUES('Heat Syncope');
INSERT INTO illnesses(nom) VALUES('Respiratory Infection');

INSERT INTO Diagnoses(
    id_illness,
    id_Symptom,
    max_pain,
    min_pain)
    VALUES(
        1,2,7,3
    );
INSERT INTO Diagnoses(
    id_illness,
    id_Symptom,
    max_pain,
    min_pain)
    VALUES(
        1,4,5,4
    );
INSERT INTO Diagnoses(
    id_illness,
    id_Symptom,
    max_pain,
    min_pain)
    VALUES(
        1,3,8,4
    );
INSERT INTO Diagnoses(
    id_illness,
    id_Symptom,
    max_pain,
    min_pain)
    VALUES(
        1,6,8,4
    );
    
INSERT INTO Diagnoses(
    id_illness,
    id_Symptom,
    max_pain,
    min_pain)
    VALUES(
        2,5,7,1
    );
INSERT INTO Diagnoses(
    id_illness,
    id_Symptom,
    max_pain,
    min_pain)
    VALUES(
        2,2,6,2
    );
INSERT INTO Diagnoses(
    id_illness,
    id_Symptom,
    max_pain,
    min_pain)
    VALUES(
        2,6,4,1
    );
INSERT INTO Diagnoses(
    id_illness,
    id_Symptom,
    max_pain,
    min_pain)
    VALUES(
        2,4,6,5
    );
INSERT INTO Diagnoses(
    id_illness,
    id_Symptom,
    max_pain,
    min_pain)
    VALUES(
        3,2,5,1
    );
INSERT INTO Diagnoses(
    id_illness,
    id_Symptom,
    max_pain,
    min_pain)
    VALUES(
        3,1,4,1
    );
INSERT INTO Diagnoses(
    id_illness,
    id_Symptom,
    max_pain,
    min_pain)
    VALUES(
        3,6,3,1 
    ):
INSERT INTO Diagnoses(
    id_illness,
    id_Symptom,
    max_pain,
    min_pain)
    VALUES(
        4,7,8,4
    );
INSERT INTO Diagnoses(
    id_illness,
    id_Symptom,
    max_pain,
    min_pain)
    VALUES(
        4,8,10,5
    );
INSERT INTO Diagnoses(
    id_illness,
    id_Symptom,
    max_pain,
    min_pain)
    VALUES(
        4,6,3,1
    );
INSERT INTO Diagnoses(
    id_illness,
    id_Symptom,
    max_pain,
    min_pain)
    VALUES(
        5,1,5,2
    );
INSERT INTO Diagnoses(
    id_illness,
    id_Symptom,
    max_pain,
    min_pain)
    VALUES(
        5,6,3,1
    );
INSERT INTO Diagnoses(
    id_illness,
    id_Symptom,
    max_pain,
    min_pain)
    VALUES(
        6,6,6,2
    );
INSERT INTO Diagnoses(
    id_illness,
    id_Symptom,
    max_pain,
    min_pain)
    VALUES(
        6,1,4,1
    );
INSERT INTO Diagnoses(
    id_illness,
    id_Symptom,
    max_pain,
    min_pain)
    VALUES(
        7,5,8,5
    );
INSERT INTO Diagnoses(
    id_illness,
    id_Symptom,
    max_pain,
    min_pain)
    VALUES(
        8,4,9,6
    );
INSERT INTO Diagnoses(
    id_illness,
    id_Symptom,
    max_pain,
    min_pain)
    VALUES(
        8,3,7,4
    );

INSERT INTO meds(nom) VALUES('pseudoephedrine');
INSERT INTO meds(nom) VALUES('Tamiflu');
INSERT INTO meds(nom) VALUES('amoxicillin');
INSERT INTO meds(nom) VALUES('loperamide');
INSERT INTO meds(nom) VALUES('ibuprofen');
INSERT INTO meds(nom) VALUES('just sleep lol');
INSERT INTO meds(nom) VALUES('just drink lol');
INSERT INTO meds(nom) VALUES('cetirizine');

CREATE TABLE pseudoephedrine(
    id_illness int,
    FOREIGN KEY (id_illness) References illnesses(id)
    efficiency int
);
INSERT INTO pseudoephedrine VALUES(1,8);
INSERT INTO pseudoephedrine VALUES(2,6);
INSERT INTO pseudoephedrine VALUES(3,3);
INSERT INTO pseudoephedrine VALUES(4,0);
INSERT INTO pseudoephedrine VALUES(5,2);
INSERT INTO pseudoephedrine VALUES(6,0);
INSERT INTO pseudoephedrine VALUES(7,0);
INSERT INTO pseudoephedrine VALUES(8,1);

CREATE TABLE tamiflu(
    id_illness int,
    FOREIGN KEY (id_illness) References illnesses(id)
    efficiency int
);
INSERT INTO tamiflu VALUES(1,3);
INSERT INTO tamiflu VALUES(2,8);
INSERT INTO tamiflu VALUES(3,2);
INSERT INTO tamiflu VALUES(4,0);
INSERT INTO tamiflu VALUES(5,0);
INSERT INTO tamiflu VALUES(6,0);
INSERT INTO tamiflu VALUES(7,0);
INSERT INTO tamiflu VALUES(8,0);

CREATE TABLE amoxicillin(
    id_illness int,
    FOREIGN KEY (id_illness) References illnesses(id)
    efficiency int
);
INSERT INTO amoxicillin VALUES(3,1,1);
INSERT INTO amoxicillin VALUES(3,2,2);
INSERT INTO amoxicillin VALUES(3,3,9);
INSERT INTO amoxicillin VALUES(3,4,0);
INSERT INTO amoxicillin VALUES(3,5,0);
INSERT INTO amoxicillin VALUES(3,6,0);
INSERT INTO amoxicillin VALUES(3,7,0);
INSERT INTO amoxicillin VALUES(3,8,0);

INSERT INTO efficiency VALUES(4,1,0);
INSERT INTO efficiency VALUES(4,2,0);
INSERT INTO efficiency VALUES(4,3,0);
INSERT INTO efficiency VALUES(4,4,9);
INSERT INTO efficiency VALUES(4,5,0);
INSERT INTO efficiency VALUES(4,6,0);
INSERT INTO efficiency VALUES(4,7,0);
INSERT INTO efficiency VALUES(4,8,0);

INSERT INTO efficiency VALUES(5,1,5);
INSERT INTO efficiency VALUES(5,2,2);
INSERT INTO efficiency VALUES(5,3,4);
INSERT INTO efficiency VALUES(5,4,0);
INSERT INTO efficiency VALUES(5,5,8);
INSERT INTO efficiency VALUES(5,6,5);
INSERT INTO efficiency VALUES(5,7,2);
INSERT INTO efficiency VALUES(5,8,1);

INSERT INTO efficiency VALUES(6,1,3);
INSERT INTO efficiency VALUES(6,2,3);
INSERT INTO efficiency VALUES(6,3,2);
INSERT INTO efficiency VALUES(6,4,1);
INSERT INTO efficiency VALUES(6,5,5);
INSERT INTO efficiency VALUES(6,6,9);
INSERT INTO efficiency VALUES(6,7,2);
INSERT INTO efficiency VALUES(6,8,0);

INSERT INTO efficiency VALUES(7,1,0);
INSERT INTO efficiency VALUES(7,2,0);
INSERT INTO efficiency VALUES(7,3,0);
INSERT INTO efficiency VALUES(7,4,0);
INSERT INTO efficiency VALUES(7,5,0);
INSERT INTO efficiency VALUES(7,6,0);
INSERT INTO efficiency VALUES(7,7,9);
INSERT INTO efficiency VALUES(7,8,0);

INSERT INTO efficiency VALUES(8,1,7);
INSERT INTO efficiency VALUES(8,2,2);
INSERT INTO efficiency VALUES(8,3,4);
INSERT INTO efficiency VALUES(8,4,0);
INSERT INTO efficiency VALUES(8,5,0);
INSERT INTO efficiency VALUES(8,6,0);
INSERT INTO efficiency VALUES(8,7,0);
INSERT INTO efficiency VALUES(8,8,9);

CREATE TABLE Log_symptoms(
    id_Symptom int,
    FOREIGN KEY (id_Symptom) References symptoms(id),
    severity integer check (severity<=100)
);

INSERT INTO Log_symptoms VALUES(
    1,
    23
);

DROP TABLE Log_symptoms;