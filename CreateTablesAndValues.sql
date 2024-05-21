CREATE TABLE survey
(
	id int GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    title varchar NOT NULL
);
CREATE TABLE interview
(
    id int GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    full_person_name varchar NOT NULL,
    created_at timestamp with time zone
);
CREATE TABLE question
(
    id int GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    content varchar not null,
    survey_id int,
    CONSTRAINT survey_id_fk FOREIGN KEY(survey_id) REFERENCES survey(id)
);
CREATE TABLE answer
(
    id int GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    content varchar NOT NULL,
    question_id int,
    CONSTRAINT question_id_fk FOREIGN KEY (question_id) REFERENCES question(id)
);
CREATE TABLE result
(
    id int GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    interview_id int,
    question_id int,
    answer_id int,
    UNIQUE(interview_id, question_id),
    CONSTRAINT interview_id_fk FOREIGN KEY (interview_id) REFERENCES interview(id),
    CONSTRAINT question_id_fk FOREIGN KEY (question_id) REFERENCES question(id),
    CONSTRAINT asnwer_id_fk FOREIGN KEY (answer_id) REFERENCES answer(id)
);

INSERT INTO interview(full_person_name)
VALUES('Валерий Сошин готов к собесу :)');

INSERT INTO survey(title)
VALUES
('Опрос по месту проживания'),
('Опрос по вредным привычкам');

INSERT INTO question(content, survey_id)
VALUES
('Где вы проживаете?', 1),
('Как вы относитесь к курению?', 2),
('Как долго вы добираетесь до соседних городов?', 1);

INSERT INTO answer(content, question_id)
VALUES
('Торжок', 1),
('Тверь', 1),
('Москва', 1),
('Положительно', 2),
('Отрицательно', 2),
('Нейтрально', 2);