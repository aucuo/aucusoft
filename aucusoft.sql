-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.2:3306
-- Время создания: Апр 21 2024 г., 23:16
-- Версия сервера: 8.0.24
-- Версия PHP: 7.4.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `aucusoft`
--

-- --------------------------------------------------------

--
-- Структура таблицы `clientfeedback`
--

CREATE TABLE `clientfeedback` (
  `FeedbackID` int NOT NULL,
  `ProjectID` int DEFAULT NULL,
  `ClientID` int DEFAULT NULL,
  `Date` date DEFAULT NULL,
  `Text` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Структура таблицы `clients`
--

CREATE TABLE `clients` (
  `ClientID` int NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Industry` varchar(255) DEFAULT NULL,
  `ContactPerson` varchar(255) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `Phone` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Структура таблицы `departments`
--

CREATE TABLE `departments` (
  `DepartmentID` int NOT NULL,
  `Name` varchar(255) NOT NULL,
  `ManagerID` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Структура таблицы `employees`
--

CREATE TABLE `employees` (
  `EmployeeID` int NOT NULL,
  `Name` varchar(255) NOT NULL,
  `PositionID` int DEFAULT NULL,
  `DepartmentID` int DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `Phone` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Структура таблицы `employeetasks`
--

CREATE TABLE `employeetasks` (
  `EmployeeTaskID` int NOT NULL,
  `TaskID` int DEFAULT NULL,
  `EmployeeID` int DEFAULT NULL,
  `TimeSpent` int DEFAULT NULL,
  `Date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Структура таблицы `managers`
--

CREATE TABLE `managers` (
  `ManagerID` int NOT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `Position` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Структура таблицы `meetings`
--

CREATE TABLE `meetings` (
  `MeetingID` int NOT NULL,
  `ProjectID` int DEFAULT NULL,
  `MeetingDate` date DEFAULT NULL,
  `Agenda` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Структура таблицы `positions`
--

CREATE TABLE `positions` (
  `PositionID` int NOT NULL,
  `Title` varchar(255) NOT NULL,
  `SalaryGrade` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Структура таблицы `projectdocuments`
--

CREATE TABLE `projectdocuments` (
  `DocumentID` int NOT NULL,
  `ProjectID` int DEFAULT NULL,
  `Title` varchar(255) NOT NULL,
  `DocumentPath` varchar(255) DEFAULT NULL,
  `CreationDate` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Структура таблицы `projects`
--

CREATE TABLE `projects` (
  `ProjectID` int NOT NULL,
  `Name` varchar(255) NOT NULL,
  `StartDate` date DEFAULT NULL,
  `EndDate` date DEFAULT NULL,
  `Budget` decimal(10,2) DEFAULT NULL,
  `ClientID` int DEFAULT NULL,
  `ProjectManagerID` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Структура таблицы `projecttechnologies`
--

CREATE TABLE `projecttechnologies` (
  `ProjectTechnologyID` int NOT NULL,
  `ProjectID` int DEFAULT NULL,
  `TechnologyID` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Структура таблицы `tasks`
--

CREATE TABLE `tasks` (
  `TaskID` int NOT NULL,
  `ProjectID` int DEFAULT NULL,
  `AssignedTo` int DEFAULT NULL,
  `Description` text,
  `StartDate` date DEFAULT NULL,
  `EndDate` date DEFAULT NULL,
  `StatusID` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Структура таблицы `taskstatuses`
--

CREATE TABLE `taskstatuses` (
  `StatusID` int NOT NULL,
  `Name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Структура таблицы `technologies`
--

CREATE TABLE `technologies` (
  `TechnologyID` int NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Description` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Структура таблицы `worklogs`
--

CREATE TABLE `worklogs` (
  `WorkLogID` int NOT NULL,
  `EmployeeID` int DEFAULT NULL,
  `ProjectID` int DEFAULT NULL,
  `HoursWorked` int DEFAULT NULL,
  `Date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Индексы таблицы `clientfeedback`
--
ALTER TABLE `clientfeedback`
  ADD PRIMARY KEY (`FeedbackID`),
  ADD KEY `ProjectID` (`ProjectID`),
  ADD KEY `ClientID` (`ClientID`);

--
-- Индексы таблицы `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`ClientID`);

--
-- Индексы таблицы `departments`
--
ALTER TABLE `departments`
  ADD PRIMARY KEY (`DepartmentID`),
  ADD KEY `fk_departments_managers` (`ManagerID`);

--
-- Индексы таблицы `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`EmployeeID`),
  ADD KEY `PositionID` (`PositionID`),
  ADD KEY `DepartmentID` (`DepartmentID`);

--
-- Индексы таблицы `employeetasks`
--
ALTER TABLE `employeetasks`
  ADD PRIMARY KEY (`EmployeeTaskID`),
  ADD KEY `TaskID` (`TaskID`),
  ADD KEY `employeetasks_ibfk_2` (`EmployeeID`);

--
-- Индексы таблицы `managers`
--
ALTER TABLE `managers`
  ADD PRIMARY KEY (`ManagerID`);

--
-- Индексы таблицы `meetings`
--
ALTER TABLE `meetings`
  ADD PRIMARY KEY (`MeetingID`),
  ADD KEY `ProjectID` (`ProjectID`);

--
-- Индексы таблицы `positions`
--
ALTER TABLE `positions`
  ADD PRIMARY KEY (`PositionID`);

--
-- Индексы таблицы `projectdocuments`
--
ALTER TABLE `projectdocuments`
  ADD PRIMARY KEY (`DocumentID`),
  ADD KEY `ProjectID` (`ProjectID`);

--
-- Индексы таблицы `projects`
--
ALTER TABLE `projects`
  ADD PRIMARY KEY (`ProjectID`),
  ADD KEY `ClientID` (`ClientID`),
  ADD KEY `ProjectManagerID` (`ProjectManagerID`);

--
-- Индексы таблицы `projecttechnologies`
--
ALTER TABLE `projecttechnologies`
  ADD PRIMARY KEY (`ProjectTechnologyID`),
  ADD KEY `ProjectID` (`ProjectID`),
  ADD KEY `TechnologyID` (`TechnologyID`);

--
-- Индексы таблицы `tasks`
--
ALTER TABLE `tasks`
  ADD PRIMARY KEY (`TaskID`),
  ADD KEY `ProjectID` (`ProjectID`),
  ADD KEY `AssignedTo` (`AssignedTo`),
  ADD KEY `StatusID` (`StatusID`);

--
-- Индексы таблицы `taskstatuses`
--
ALTER TABLE `taskstatuses`
  ADD PRIMARY KEY (`StatusID`);

--
-- Индексы таблицы `technologies`
--
ALTER TABLE `technologies`
  ADD PRIMARY KEY (`TechnologyID`);

--
-- Индексы таблицы `worklogs`
--
ALTER TABLE `worklogs`
  ADD PRIMARY KEY (`WorkLogID`),
  ADD KEY `EmployeeID` (`EmployeeID`),
  ADD KEY `ProjectID` (`ProjectID`);

--
-- Индексы таблицы `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `clientfeedback`
--
ALTER TABLE `clientfeedback`
  MODIFY `FeedbackID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT для таблицы `clients`
--
ALTER TABLE `clients`
  MODIFY `ClientID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT для таблицы `departments`
--
ALTER TABLE `departments`
  MODIFY `DepartmentID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `employees`
--
ALTER TABLE `employees`
  MODIFY `EmployeeID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `employeetasks`
--
ALTER TABLE `employeetasks`
  MODIFY `EmployeeTaskID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `managers`
--
ALTER TABLE `managers`
  MODIFY `ManagerID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT для таблицы `meetings`
--
ALTER TABLE `meetings`
  MODIFY `MeetingID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT для таблицы `positions`
--
ALTER TABLE `positions`
  MODIFY `PositionID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `projectdocuments`
--
ALTER TABLE `projectdocuments`
  MODIFY `DocumentID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `projects`
--
ALTER TABLE `projects`
  MODIFY `ProjectID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT для таблицы `projecttechnologies`
--
ALTER TABLE `projecttechnologies`
  MODIFY `ProjectTechnologyID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `tasks`
--
ALTER TABLE `tasks`
  MODIFY `TaskID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `taskstatuses`
--
ALTER TABLE `taskstatuses`
  MODIFY `StatusID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `technologies`
--
ALTER TABLE `technologies`
  MODIFY `TechnologyID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `worklogs`
--
ALTER TABLE `worklogs`
  MODIFY `WorkLogID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `clientfeedback`
--
ALTER TABLE `clientfeedback`
  ADD CONSTRAINT `clientfeedback_ibfk_1` FOREIGN KEY (`ProjectID`) REFERENCES `projects` (`ProjectID`),
  ADD CONSTRAINT `clientfeedback_ibfk_2` FOREIGN KEY (`ClientID`) REFERENCES `clients` (`ClientID`);

--
-- Ограничения внешнего ключа таблицы `departments`
--
ALTER TABLE `departments`
  ADD CONSTRAINT `fk_departments_managers` FOREIGN KEY (`ManagerID`) REFERENCES `managers` (`ManagerID`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `employees`
--
ALTER TABLE `employees`
  ADD CONSTRAINT `employees_ibfk_1` FOREIGN KEY (`PositionID`) REFERENCES `positions` (`PositionID`),
  ADD CONSTRAINT `employees_ibfk_2` FOREIGN KEY (`DepartmentID`) REFERENCES `departments` (`DepartmentID`);

--
-- Ограничения внешнего ключа таблицы `employeetasks`
--
ALTER TABLE `employeetasks`
  ADD CONSTRAINT `employeetasks_ibfk_1` FOREIGN KEY (`TaskID`) REFERENCES `tasks` (`TaskID`),
  ADD CONSTRAINT `employeetasks_ibfk_2` FOREIGN KEY (`EmployeeID`) REFERENCES `employees` (`EmployeeID`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `meetings`
--
ALTER TABLE `meetings`
  ADD CONSTRAINT `meetings_ibfk_1` FOREIGN KEY (`ProjectID`) REFERENCES `projects` (`ProjectID`);

--
-- Ограничения внешнего ключа таблицы `projectdocuments`
--
ALTER TABLE `projectdocuments`
  ADD CONSTRAINT `projectdocuments_ibfk_1` FOREIGN KEY (`ProjectID`) REFERENCES `projects` (`ProjectID`);

--
-- Ограничения внешнего ключа таблицы `projects`
--
ALTER TABLE `projects`
  ADD CONSTRAINT `projects_ibfk_1` FOREIGN KEY (`ClientID`) REFERENCES `clients` (`ClientID`),
  ADD CONSTRAINT `projects_ibfk_2` FOREIGN KEY (`ProjectManagerID`) REFERENCES `employees` (`EmployeeID`);

--
-- Ограничения внешнего ключа таблицы `projecttechnologies`
--
ALTER TABLE `projecttechnologies`
  ADD CONSTRAINT `projecttechnologies_ibfk_1` FOREIGN KEY (`ProjectID`) REFERENCES `projects` (`ProjectID`),
  ADD CONSTRAINT `projecttechnologies_ibfk_2` FOREIGN KEY (`TechnologyID`) REFERENCES `technologies` (`TechnologyID`);

--
-- Ограничения внешнего ключа таблицы `tasks`
--
ALTER TABLE `tasks`
  ADD CONSTRAINT `tasks_ibfk_1` FOREIGN KEY (`ProjectID`) REFERENCES `projects` (`ProjectID`),
  ADD CONSTRAINT `tasks_ibfk_2` FOREIGN KEY (`AssignedTo`) REFERENCES `employees` (`EmployeeID`),
  ADD CONSTRAINT `tasks_ibfk_3` FOREIGN KEY (`StatusID`) REFERENCES `taskstatuses` (`StatusID`);

--
-- Ограничения внешнего ключа таблицы `worklogs`
--
ALTER TABLE `worklogs`
  ADD CONSTRAINT `worklogs_ibfk_1` FOREIGN KEY (`EmployeeID`) REFERENCES `employees` (`EmployeeID`),
  ADD CONSTRAINT `worklogs_ibfk_2` FOREIGN KEY (`ProjectID`) REFERENCES `projects` (`ProjectID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
