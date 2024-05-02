-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Апр 26 2024 г., 19:12
-- Версия сервера: 8.0.30
-- Версия PHP: 8.0.22

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `University`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Deanery`
--

CREATE TABLE `Deanery` (
  `DeaneryID` int NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Dean` varchar(255) NOT NULL,
  `Deanery_number` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Deanery`
--

INSERT INTO `Deanery` (`DeaneryID`, `Name`, `Dean`, `Deanery_number`) VALUES
(1, 'Deanery of Computer Science', 'Robert Johnson', 36793),
(2, 'Deanery of Mathematics', 'Jennifer Lee', 86373),
(3, 'Deanery of Physics', 'Daniel White', 14652),
(4, 'Deanery of Chemistry', 'Sophia Martinez', 43608),
(5, 'Deanery of Biology', 'William Taylor', 36739);

-- --------------------------------------------------------

--
-- Структура таблицы `Department`
--

CREATE TABLE `Department` (
  `DepartmentID` int NOT NULL,
  `DeaneryID` int NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Head_of_department` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Department`
--

INSERT INTO `Department` (`DepartmentID`, `DeaneryID`, `Name`, `Head_of_department`) VALUES
(6, 1, 'Department of Computer Science', 'John Smith'),
(7, 1, 'Department of Mathematics', 'Alice Johnson'),
(8, 2, 'Department of Physics', 'Michael Brown'),
(9, 2, 'Department of Chemistry', 'Emily Wilson'),
(10, 3, 'Department of Biology', 'David Miller');

-- --------------------------------------------------------

--
-- Структура таблицы `Diploma`
--

CREATE TABLE `Diploma` (
  `DiplomaID` int NOT NULL,
  `StudentID` int DEFAULT NULL,
  `TeacherID` int DEFAULT NULL,
  `Topic` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `Disciplines`
--

CREATE TABLE `Disciplines` (
  `DisciplineID` int NOT NULL,
  `Name` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `Lessons`
--

CREATE TABLE `Lessons` (
  `LessonID` int NOT NULL,
  `TeachingID` int DEFAULT NULL,
  `LessonType` varchar(50) DEFAULT NULL,
  `GroupID` int DEFAULT NULL,
  `LessonDate` date DEFAULT NULL,
  `LessonTime` time DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `Research`
--

CREATE TABLE `Research` (
  `ResearchID` int NOT NULL,
  `TeacherID` int NOT NULL,
  `ResearchType` varchar(255) NOT NULL,
  `Title` varchar(255) NOT NULL,
  `DefenseDate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `Session`
--

CREATE TABLE `Session` (
  `SessionID` int NOT NULL,
  `StudentID` int DEFAULT NULL,
  `TeachingID` int DEFAULT NULL,
  `Semester` int DEFAULT NULL,
  `Form_of_control` varchar(20) DEFAULT NULL,
  `Grade` varchar(10) DEFAULT NULL,
  `Retake` enum('Yes','No') DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `Specialty`
--

CREATE TABLE `Specialty` (
  `SpecialtyID` int NOT NULL,
  `DepartmentID` int NOT NULL,
  `Name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `Students`
--

CREATE TABLE `Students` (
  `StudentID` int NOT NULL,
  `Full_name` varchar(255) NOT NULL,
  `GroupID` int NOT NULL,
  `Course` int NOT NULL,
  `Age` int NOT NULL,
  `Gender` enum('Male','Female') NOT NULL,
  `Has_children` enum('Yes','No') NOT NULL,
  `Education_form` enum('Budget','Paid') NOT NULL,
  `Scholarship` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `Student_Groups`
--

CREATE TABLE `Student_Groups` (
  `GroupID` int NOT NULL,
  `SpecialtyID` int NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Course` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `StudyPlan`
--

CREATE TABLE `StudyPlan` (
  `StudyPlanID` int NOT NULL,
  `TeachingID` int NOT NULL,
  `GroupID` int NOT NULL,
  `LessonType` varchar(255) NOT NULL,
  `HoursAmount` int NOT NULL,
  `Form_of_control` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `Teachers`
--

CREATE TABLE `Teachers` (
  `TeacherID` int NOT NULL,
  `DepartmentID` int NOT NULL,
  `Full_name` varchar(255) NOT NULL,
  `Gender` enum('Male','Female') NOT NULL,
  `Age` int NOT NULL,
  `Children_count` int DEFAULT NULL,
  `Salary` decimal(10,2) DEFAULT NULL,
  `Teachers_CategoryID` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `Teachers_Category`
--

CREATE TABLE `Teachers_Category` (
  `Teachers_CategoryID` int NOT NULL,
  `Category` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `Teaching`
--

CREATE TABLE `Teaching` (
  `TeachingID` int NOT NULL,
  `TeacherID` int DEFAULT NULL,
  `DisciplineID` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Deanery`
--
ALTER TABLE `Deanery`
  ADD PRIMARY KEY (`DeaneryID`);

--
-- Индексы таблицы `Department`
--
ALTER TABLE `Department`
  ADD PRIMARY KEY (`DepartmentID`),
  ADD KEY `DeaneryID` (`DeaneryID`);

--
-- Индексы таблицы `Diploma`
--
ALTER TABLE `Diploma`
  ADD PRIMARY KEY (`DiplomaID`),
  ADD KEY `StudentID` (`StudentID`),
  ADD KEY `TeacherID` (`TeacherID`);

--
-- Индексы таблицы `Disciplines`
--
ALTER TABLE `Disciplines`
  ADD PRIMARY KEY (`DisciplineID`);

--
-- Индексы таблицы `Lessons`
--
ALTER TABLE `Lessons`
  ADD PRIMARY KEY (`LessonID`),
  ADD KEY `TeachingID` (`TeachingID`),
  ADD KEY `GroupID` (`GroupID`);

--
-- Индексы таблицы `Research`
--
ALTER TABLE `Research`
  ADD PRIMARY KEY (`ResearchID`),
  ADD KEY `TeacherID` (`TeacherID`);

--
-- Индексы таблицы `Session`
--
ALTER TABLE `Session`
  ADD PRIMARY KEY (`SessionID`),
  ADD KEY `StudentID` (`StudentID`),
  ADD KEY `TeachingID` (`TeachingID`);

--
-- Индексы таблицы `Specialty`
--
ALTER TABLE `Specialty`
  ADD PRIMARY KEY (`SpecialtyID`),
  ADD KEY `DepartmentID` (`DepartmentID`);

--
-- Индексы таблицы `Students`
--
ALTER TABLE `Students`
  ADD PRIMARY KEY (`StudentID`),
  ADD KEY `GroupID` (`GroupID`);

--
-- Индексы таблицы `Student_Groups`
--
ALTER TABLE `Student_Groups`
  ADD PRIMARY KEY (`GroupID`),
  ADD KEY `SpecialtyID` (`SpecialtyID`);

--
-- Индексы таблицы `StudyPlan`
--
ALTER TABLE `StudyPlan`
  ADD PRIMARY KEY (`StudyPlanID`),
  ADD KEY `TeachingID` (`TeachingID`),
  ADD KEY `GroupID` (`GroupID`);

--
-- Индексы таблицы `Teachers`
--
ALTER TABLE `Teachers`
  ADD PRIMARY KEY (`TeacherID`),
  ADD KEY `DepartmentID` (`DepartmentID`),
  ADD KEY `FK_Teachers_Category` (`Teachers_CategoryID`);

--
-- Индексы таблицы `Teachers_Category`
--
ALTER TABLE `Teachers_Category`
  ADD PRIMARY KEY (`Teachers_CategoryID`);

--
-- Индексы таблицы `Teaching`
--
ALTER TABLE `Teaching`
  ADD PRIMARY KEY (`TeachingID`),
  ADD KEY `TeacherID` (`TeacherID`),
  ADD KEY `DisciplineID` (`DisciplineID`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `Deanery`
--
ALTER TABLE `Deanery`
  MODIFY `DeaneryID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `Department`
--
ALTER TABLE `Department`
  MODIFY `DepartmentID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT для таблицы `Diploma`
--
ALTER TABLE `Diploma`
  MODIFY `DiplomaID` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `Lessons`
--
ALTER TABLE `Lessons`
  MODIFY `LessonID` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `Research`
--
ALTER TABLE `Research`
  MODIFY `ResearchID` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `Session`
--
ALTER TABLE `Session`
  MODIFY `SessionID` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `Specialty`
--
ALTER TABLE `Specialty`
  MODIFY `SpecialtyID` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `Students`
--
ALTER TABLE `Students`
  MODIFY `StudentID` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `Student_Groups`
--
ALTER TABLE `Student_Groups`
  MODIFY `GroupID` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `StudyPlan`
--
ALTER TABLE `StudyPlan`
  MODIFY `StudyPlanID` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `Teachers`
--
ALTER TABLE `Teachers`
  MODIFY `TeacherID` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `Teachers_Category`
--
ALTER TABLE `Teachers_Category`
  MODIFY `Teachers_CategoryID` int NOT NULL AUTO_INCREMENT;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `Department`
--
ALTER TABLE `Department`
  ADD CONSTRAINT `department_ibfk_1` FOREIGN KEY (`DeaneryID`) REFERENCES `Deanery` (`DeaneryID`);

--
-- Ограничения внешнего ключа таблицы `Diploma`
--
ALTER TABLE `Diploma`
  ADD CONSTRAINT `diploma_ibfk_1` FOREIGN KEY (`StudentID`) REFERENCES `Students` (`StudentID`),
  ADD CONSTRAINT `diploma_ibfk_2` FOREIGN KEY (`TeacherID`) REFERENCES `Teachers` (`TeacherID`);

--
-- Ограничения внешнего ключа таблицы `Lessons`
--
ALTER TABLE `Lessons`
  ADD CONSTRAINT `lessons_ibfk_1` FOREIGN KEY (`TeachingID`) REFERENCES `Teaching` (`TeachingID`),
  ADD CONSTRAINT `lessons_ibfk_2` FOREIGN KEY (`GroupID`) REFERENCES `Student_Groups` (`GroupID`);

--
-- Ограничения внешнего ключа таблицы `Research`
--
ALTER TABLE `Research`
  ADD CONSTRAINT `research_ibfk_1` FOREIGN KEY (`TeacherID`) REFERENCES `Teachers` (`TeacherID`);

--
-- Ограничения внешнего ключа таблицы `Session`
--
ALTER TABLE `Session`
  ADD CONSTRAINT `session_ibfk_1` FOREIGN KEY (`StudentID`) REFERENCES `Students` (`StudentID`),
  ADD CONSTRAINT `session_ibfk_2` FOREIGN KEY (`TeachingID`) REFERENCES `Teaching` (`TeachingID`);

--
-- Ограничения внешнего ключа таблицы `Specialty`
--
ALTER TABLE `Specialty`
  ADD CONSTRAINT `specialty_ibfk_1` FOREIGN KEY (`DepartmentID`) REFERENCES `Department` (`DepartmentID`);

--
-- Ограничения внешнего ключа таблицы `Students`
--
ALTER TABLE `Students`
  ADD CONSTRAINT `students_ibfk_1` FOREIGN KEY (`GroupID`) REFERENCES `Student_Groups` (`GroupID`);

--
-- Ограничения внешнего ключа таблицы `Student_Groups`
--
ALTER TABLE `Student_Groups`
  ADD CONSTRAINT `student_groups_ibfk_1` FOREIGN KEY (`SpecialtyID`) REFERENCES `Specialty` (`SpecialtyID`);

--
-- Ограничения внешнего ключа таблицы `StudyPlan`
--
ALTER TABLE `StudyPlan`
  ADD CONSTRAINT `studyplan_ibfk_1` FOREIGN KEY (`TeachingID`) REFERENCES `Teaching` (`TeachingID`),
  ADD CONSTRAINT `studyplan_ibfk_2` FOREIGN KEY (`GroupID`) REFERENCES `Student_Groups` (`GroupID`);

--
-- Ограничения внешнего ключа таблицы `Teachers`
--
ALTER TABLE `Teachers`
  ADD CONSTRAINT `FK_Teachers_Category` FOREIGN KEY (`Teachers_CategoryID`) REFERENCES `Teachers_Category` (`Teachers_CategoryID`),
  ADD CONSTRAINT `teachers_ibfk_1` FOREIGN KEY (`DepartmentID`) REFERENCES `Department` (`DepartmentID`);

--
-- Ограничения внешнего ключа таблицы `Teaching`
--
ALTER TABLE `Teaching`
  ADD CONSTRAINT `teaching_ibfk_1` FOREIGN KEY (`TeacherID`) REFERENCES `Teachers` (`TeacherID`),
  ADD CONSTRAINT `teaching_ibfk_2` FOREIGN KEY (`DisciplineID`) REFERENCES `Disciplines` (`DisciplineID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
