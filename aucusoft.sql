-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.2:3306
-- Время создания: Май 01 2024 г., 01:36
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
-- База данных: `aucusoft_v2`
--

-- --------------------------------------------------------

--
-- Структура таблицы `clientfeedback`
--

CREATE TABLE `clientfeedback` (
  `FeedbackID` int NOT NULL,
  `ProjectID` int DEFAULT NULL,
  `ClientID` int DEFAULT NULL,
  `Date` datetime(6) DEFAULT NULL,
  `Text` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `clientfeedback`
--

INSERT INTO `clientfeedback` (`FeedbackID`, `ProjectID`, `ClientID`, `Date`, `Text`) VALUES
(2, 1, 2, '2024-03-15 00:00:00.000000', 'The project was delivered on time, but there were some issues with the initial deployment.'),
(3, 3, 3, '2024-04-15 00:00:00.000000', 'Excellent communication and project management.'),
(6, 1, 5, '2024-02-15 00:00:00.000000', 'Updated feedback text due to client review.'),
(8, 4, 2, '2024-07-01 00:00:00.000000', 'This is a newly added feedback.');

-- --------------------------------------------------------

--
-- Структура таблицы `clients`
--

CREATE TABLE `clients` (
  `ClientID` int NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Industry` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `ContactPerson` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Phone` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `clients`
--

INSERT INTO `clients` (`ClientID`, `Name`, `Industry`, `ContactPerson`, `Email`, `Phone`) VALUES
(2, 'Beta LLC', 'Finance', 'Jane Smith', 'janesmith@betallc.com', '80293284224'),
(3, 'Gamma Inc', 'Healthcare', 'Mike Brown', 'mikebrown@gammainc.com', '80293284224'),
(4, 'Delta Technologies', 'Education', 'Susan Clark', 'susanclark@deltatech.com', '80293284224'),
(5, 'Epsilon Services', 'Retail', 'Alex Johnson', 'alexjohnson@epsilonservices.com', '80293284224'),
(6, 'Aucusoft', 'Finance', 'Egor Shikovets', 'Egor Shikovets@example.com', '80293284224');

-- --------------------------------------------------------

--
-- Структура таблицы `departments`
--

CREATE TABLE `departments` (
  `DepartmentID` int NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ManagerID` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `departments`
--

INSERT INTO `departments` (`DepartmentID`, `Name`, `ManagerID`) VALUES
(1, 'Development', 1),
(2, 'Sales', 2),
(3, 'HR', 3),
(4, 'Marketing', 4),
(5, 'Finance', 8),
(6, 'IT', 9);

-- --------------------------------------------------------

--
-- Структура таблицы `employees`
--

CREATE TABLE `employees` (
  `EmployeeID` int NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PositionID` int DEFAULT NULL,
  `DepartmentID` int DEFAULT NULL,
  `Email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Phone` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `employees`
--

INSERT INTO `employees` (`EmployeeID`, `Name`, `PositionID`, `DepartmentID`, `Email`, `Phone`) VALUES
(1, 'Ivan Ivanov', 2, 1, 'new_email@example.com', '1234567890'),
(2, 'Petr Petrov', 2, 2, 'petrov@example.com', '0987654321'),
(3, 'Sidor Sidorov', 3, 3, 'sidorov@example.com', '1122334455'),
(4, 'Anna Annanova', 4, 6, 'annanova@example.com', '2233445566'),
(5, 'Olga Olganova2', 5, 5, 'olganova@example.com', '3344556677');

-- --------------------------------------------------------

--
-- Структура таблицы `employeetasks`
--

CREATE TABLE `employeetasks` (
  `EmployeeTaskID` int NOT NULL,
  `TaskID` int DEFAULT NULL,
  `EmployeeID` int DEFAULT NULL,
  `TimeSpent` int DEFAULT NULL,
  `Date` datetime(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `employeetasks`
--

INSERT INTO `employeetasks` (`EmployeeTaskID`, `TaskID`, `EmployeeID`, `TimeSpent`, `Date`) VALUES
(1, 1, 1, 8, '2024-02-01 00:00:00.000000'),
(2, 2, 1, 6, '2024-02-12 00:00:00.000000'),
(3, 3, 1, 7, '2024-02-06 00:00:00.000000'),
(4, 4, 3, 8, '2024-02-17 00:00:00.000000'),
(5, 5, 2, 5, '2024-02-27 00:00:00.000000');

-- --------------------------------------------------------

--
-- Структура таблицы `managers`
--

CREATE TABLE `managers` (
  `ManagerID` int NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Position` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `managers`
--

INSERT INTO `managers` (`ManagerID`, `Name`, `Position`) VALUES
(1, 'Alexey Petrov', 'Senior Project Manager'),
(2, 'Maria Ivanova', 'Project Manager'),
(3, 'Igor Sidorov', 'IT Manager'),
(4, 'Elena Popova', 'Development Manager'),
(5, 'Dmitry Kuznetsov', 'Product Manager'),
(8, 'Egor Shikovets', 'Lead of company'),
(9, 'Jane Smith', 'Account Manager');

-- --------------------------------------------------------

--
-- Структура таблицы `meetings`
--

CREATE TABLE `meetings` (
  `MeetingID` int NOT NULL,
  `ProjectID` int DEFAULT NULL,
  `MeetingDate` datetime(6) DEFAULT NULL,
  `Agenda` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `meetings`
--

INSERT INTO `meetings` (`MeetingID`, `ProjectID`, `MeetingDate`, `Agenda`) VALUES
(3, 2, '2003-08-24 00:00:00.000000', 'Промежуточный отчет'),
(4, 2, '2024-04-20 00:00:00.000000', 'Тестирование продукта'),
(5, 3, '2024-05-10 00:00:00.000000', 'Запуск проекта');

-- --------------------------------------------------------

--
-- Структура таблицы `positions`
--

CREATE TABLE `positions` (
  `PositionID` int NOT NULL,
  `Title` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `SalaryGrade` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `positions`
--

INSERT INTO `positions` (`PositionID`, `Title`, `SalaryGrade`) VALUES
(1, 'Software Developer', 2),
(2, 'Project Manager', 1),
(3, 'Quality Assurance Engineer', 3),
(4, 'UI/UX Designer', 4),
(5, 'System Analyst', 1);

-- --------------------------------------------------------

--
-- Структура таблицы `projectdocuments`
--

CREATE TABLE `projectdocuments` (
  `DocumentID` int NOT NULL,
  `ProjectID` int DEFAULT NULL,
  `Title` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DocumentPath` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CreationDate` datetime(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `projectdocuments`
--

INSERT INTO `projectdocuments` (`DocumentID`, `ProjectID`, `Title`, `DocumentPath`, `CreationDate`) VALUES
(1, 1, 'Техническое задание', '/docs/project1/specification.pdf', '2024-02-23 00:00:00.000000'),
(2, 2, 'План проекта', '/docs/project1/plan.pdf', '2024-02-20 00:00:00.000000'),
(3, 2, 'Архитектура системы', '/docs/project2/architecture.pdf', '2024-03-01 00:00:00.000000'),
(4, 3, 'Тестовый план', '/docs/project3/test_plan.pdf', '2024-03-15 00:00:00.000000'),
(5, 4, 'Пользовательская документация', '/docs/project4/user_guide.pdf', '2024-04-01 00:00:00.000000');

-- --------------------------------------------------------

--
-- Структура таблицы `projects`
--

CREATE TABLE `projects` (
  `ProjectID` int NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `StartDate` datetime(6) DEFAULT NULL,
  `EndDate` datetime(6) DEFAULT NULL,
  `Budget` decimal(10,2) DEFAULT NULL,
  `ClientID` int DEFAULT NULL,
  `ManagerId` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `projects`
--

INSERT INTO `projects` (`ProjectID`, `Name`, `StartDate`, `EndDate`, `Budget`, `ClientID`, `ManagerId`) VALUES
(1, 'Project Alphaaa', '2024-04-29 00:00:00.000000', '2024-03-02 00:00:00.000000', '121000.00', 5, 8),
(2, 'Project Beta', '2024-03-01 00:00:00.000000', '2024-02-22 00:00:00.000000', '192500.00', 2, 1),
(3, 'Project Gamma', '2024-04-01 00:00:00.000000', '2024-02-21 00:00:00.000000', '253000.00', 5, 2),
(4, 'Project Delta2', '2023-05-01 00:00:00.000000', '2024-11-01 00:00:00.000000', '313500.00', 4, 4),
(5, 'Project Epsilon', '2024-06-01 00:00:00.000000', '2024-05-28 00:00:00.000000', '374000.00', 6, 3),
(6, 'New Project', '2024-01-01 00:00:00.000000', '2024-12-31 00:00:00.000000', '121000.00', NULL, 2),
(7, 'New Project', '2024-01-01 00:00:00.000000', '2024-12-31 00:00:00.000000', '121000.00', 2, 1),
(8, 'New Project', '2024-01-01 00:00:00.000000', '2024-12-31 00:00:00.000000', '121000.00', 3, 3),
(9, 'New Project', '2024-01-01 00:00:00.000000', '2024-12-31 00:00:00.000000', '121000.00', 4, 5),
(10, 'New Project', '2024-01-09 00:00:00.000000', '2024-12-31 00:00:00.000000', '121000.00', 2, 8),
(11, 'Tttest4', '2024-04-21 00:00:00.000000', '2024-04-10 00:00:00.000000', '22.00', 2, 1),
(12, 'Example', '2024-04-11 00:00:00.000000', '2024-04-20 00:00:00.000000', '32433.00', 2, 4),
(13, 'TEST2', '2024-04-25 00:00:00.000000', '2024-04-13 00:00:00.000000', '1111.00', 3, 1),
(14, 'teStTt3', '2024-04-12 00:00:00.000000', '2024-04-21 00:00:00.000000', '24.00', 2, 2);

-- --------------------------------------------------------

--
-- Структура таблицы `projecttechnologies`
--

CREATE TABLE `projecttechnologies` (
  `ProjectTechnologyID` int NOT NULL,
  `ProjectID` int DEFAULT NULL,
  `TechnologyID` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `projecttechnologies`
--

INSERT INTO `projecttechnologies` (`ProjectTechnologyID`, `ProjectID`, `TechnologyID`) VALUES
(1, 1, 1),
(2, 1, 2),
(3, 2, 3),
(4, 3, 4),
(5, 4, 5);

-- --------------------------------------------------------

--
-- Структура таблицы `tasks`
--

CREATE TABLE `tasks` (
  `TaskID` int NOT NULL,
  `ProjectID` int DEFAULT NULL,
  `EmployeeID` int DEFAULT NULL,
  `Description` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `StartDate` datetime(6) DEFAULT NULL,
  `EndDate` datetime(6) DEFAULT NULL,
  `StatusID` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `tasks`
--

INSERT INTO `tasks` (`TaskID`, `ProjectID`, `EmployeeID`, `Description`, `StartDate`, `EndDate`, `StatusID`) VALUES
(1, 1, 1, 'Database design', '2024-02-01 00:00:00.000000', '2024-02-01 00:00:00.000000', 3),
(2, 1, 2, 'API development', '2024-02-11 00:00:00.000000', '2024-02-20 00:00:00.000000', 3),
(3, 2, 1, 'Frontend setup', '2024-02-05 00:00:00.000000', '2024-02-15 00:00:00.000000', 2),
(4, 2, 3, 'Backend logic', '2024-02-16 00:00:00.000000', '2024-02-25 00:00:00.000000', 1),
(5, 3, 2, 'Testing', '2024-02-26 00:00:00.000000', '2024-03-07 00:00:00.000000', 1);

-- --------------------------------------------------------

--
-- Структура таблицы `taskstatuses`
--

CREATE TABLE `taskstatuses` (
  `StatusID` int NOT NULL,
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `taskstatuses`
--

INSERT INTO `taskstatuses` (`StatusID`, `Name`) VALUES
(1, 'Not Started'),
(2, 'In Progress'),
(3, 'Completed'),
(4, 'On Hold'),
(5, 'Cancelled');

-- --------------------------------------------------------

--
-- Структура таблицы `technologies`
--

CREATE TABLE `technologies` (
  `TechnologyID` int NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `technologies`
--

INSERT INTO `technologies` (`TechnologyID`, `Name`, `Description`) VALUES
(1, 'Java', 'Язык программирования для разработки серверной части'),
(2, 'React', 'Библиотека для создания пользовательских интерфейсов'),
(3, 'Docker', 'Платформа для контейнеризации приложений'),
(4, 'Kubernetes', 'Система управления контейнеризированными приложениями'),
(5, 'TensorFlow', 'Открытая библиотека для машинного обучения');

-- --------------------------------------------------------

--
-- Структура таблицы `worklogs`
--

CREATE TABLE `worklogs` (
  `WorkLogID` int NOT NULL,
  `EmployeeID` int DEFAULT NULL,
  `ProjectID` int DEFAULT NULL,
  `HoursWorked` int DEFAULT NULL,
  `Date` datetime(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `worklogs`
--

INSERT INTO `worklogs` (`WorkLogID`, `EmployeeID`, `ProjectID`, `HoursWorked`, `Date`) VALUES
(1, 1, 1, 8, '2024-02-15 00:00:00.000000'),
(2, 2, 1, 6, '2024-02-16 00:00:00.000000'),
(3, 3, 2, 7, '2024-02-17 00:00:00.000000'),
(4, 4, 2, 8, '2024-02-18 00:00:00.000000'),
(5, 5, 3, 5, '2024-02-19 00:00:00.000000');

-- --------------------------------------------------------

--
-- Структура таблицы `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20240421214138_UniversityProjectInit', '7.0.18'),
('20240425004451_UpdatedContext', '7.0.18'),
('20240425005257_DatabaseSetup_v2', '7.0.18'),
('20240429012423_ProjectFixes', '7.0.18'),
('20240430134806_ProjectFixes_v2', '7.0.18'),
('20240430135008_ProjectFixes_v3', '7.0.18'),
('20240430144358_DeletedAssignedToInTasks', '7.0.18'),
('20240430144814_DeletedAssignedToInTasks_v2', '7.0.18');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `clientfeedback`
--
ALTER TABLE `clientfeedback`
  ADD PRIMARY KEY (`FeedbackID`),
  ADD KEY `ClientID` (`ClientID`),
  ADD KEY `ProjectID` (`ProjectID`);

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
  ADD KEY `DepartmentID` (`DepartmentID`),
  ADD KEY `PositionID` (`PositionID`);

--
-- Индексы таблицы `employeetasks`
--
ALTER TABLE `employeetasks`
  ADD PRIMARY KEY (`EmployeeTaskID`),
  ADD KEY `employeetasks_ibfk_2` (`EmployeeID`),
  ADD KEY `TaskID` (`TaskID`);

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
  ADD KEY `ProjectID1` (`ProjectID`);

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
  ADD KEY `ProjectID2` (`ProjectID`);

--
-- Индексы таблицы `projects`
--
ALTER TABLE `projects`
  ADD PRIMARY KEY (`ProjectID`),
  ADD KEY `ClientID1` (`ClientID`),
  ADD KEY `ManagerId` (`ManagerId`);

--
-- Индексы таблицы `projecttechnologies`
--
ALTER TABLE `projecttechnologies`
  ADD PRIMARY KEY (`ProjectTechnologyID`),
  ADD KEY `ProjectID3` (`ProjectID`),
  ADD KEY `TechnologyID` (`TechnologyID`);

--
-- Индексы таблицы `tasks`
--
ALTER TABLE `tasks`
  ADD PRIMARY KEY (`TaskID`),
  ADD KEY `IX_tasks_EmployeeID` (`EmployeeID`),
  ADD KEY `ProjectID4` (`ProjectID`),
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
  ADD KEY `ProjectID5` (`ProjectID`);

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
  MODIFY `ManagerID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT для таблицы `meetings`
--
ALTER TABLE `meetings`
  MODIFY `MeetingID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

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
  MODIFY `ProjectID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT для таблицы `projecttechnologies`
--
ALTER TABLE `projecttechnologies`
  MODIFY `ProjectTechnologyID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `tasks`
--
ALTER TABLE `tasks`
  MODIFY `TaskID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

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
  ADD CONSTRAINT `clientfeedback_ibfk_1` FOREIGN KEY (`ProjectID`) REFERENCES `projects` (`ProjectID`) ON DELETE CASCADE,
  ADD CONSTRAINT `clientfeedback_ibfk_2` FOREIGN KEY (`ClientID`) REFERENCES `clients` (`ClientID`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `departments`
--
ALTER TABLE `departments`
  ADD CONSTRAINT `fk_departments_managers` FOREIGN KEY (`ManagerID`) REFERENCES `managers` (`ManagerID`) ON DELETE SET NULL;

--
-- Ограничения внешнего ключа таблицы `employees`
--
ALTER TABLE `employees`
  ADD CONSTRAINT `employees_ibfk_1` FOREIGN KEY (`PositionID`) REFERENCES `positions` (`PositionID`) ON DELETE SET NULL,
  ADD CONSTRAINT `employees_ibfk_2` FOREIGN KEY (`DepartmentID`) REFERENCES `departments` (`DepartmentID`) ON DELETE SET NULL;

--
-- Ограничения внешнего ключа таблицы `employeetasks`
--
ALTER TABLE `employeetasks`
  ADD CONSTRAINT `employeetasks_ibfk_1` FOREIGN KEY (`TaskID`) REFERENCES `tasks` (`TaskID`) ON DELETE CASCADE,
  ADD CONSTRAINT `employeetasks_ibfk_2` FOREIGN KEY (`EmployeeID`) REFERENCES `employees` (`EmployeeID`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `meetings`
--
ALTER TABLE `meetings`
  ADD CONSTRAINT `meetings_ibfk_1` FOREIGN KEY (`ProjectID`) REFERENCES `projects` (`ProjectID`) ON DELETE SET NULL;

--
-- Ограничения внешнего ключа таблицы `projectdocuments`
--
ALTER TABLE `projectdocuments`
  ADD CONSTRAINT `projectdocuments_ibfk_1` FOREIGN KEY (`ProjectID`) REFERENCES `projects` (`ProjectID`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `projects`
--
ALTER TABLE `projects`
  ADD CONSTRAINT `projects_ibfk_1` FOREIGN KEY (`ClientID`) REFERENCES `clients` (`ClientID`) ON DELETE SET NULL,
  ADD CONSTRAINT `projects_ibfk_2` FOREIGN KEY (`ManagerId`) REFERENCES `managers` (`ManagerID`) ON DELETE SET NULL;

--
-- Ограничения внешнего ключа таблицы `projecttechnologies`
--
ALTER TABLE `projecttechnologies`
  ADD CONSTRAINT `projecttechnologies_ibfk_1` FOREIGN KEY (`ProjectID`) REFERENCES `projects` (`ProjectID`) ON DELETE CASCADE,
  ADD CONSTRAINT `projecttechnologies_ibfk_2` FOREIGN KEY (`TechnologyID`) REFERENCES `technologies` (`TechnologyID`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `tasks`
--
ALTER TABLE `tasks`
  ADD CONSTRAINT `FK_tasks_employees_EmployeeID` FOREIGN KEY (`EmployeeID`) REFERENCES `employees` (`EmployeeID`),
  ADD CONSTRAINT `tasks_ibfk_1` FOREIGN KEY (`ProjectID`) REFERENCES `projects` (`ProjectID`) ON DELETE CASCADE,
  ADD CONSTRAINT `tasks_ibfk_3` FOREIGN KEY (`StatusID`) REFERENCES `taskstatuses` (`StatusID`) ON DELETE SET NULL;

--
-- Ограничения внешнего ключа таблицы `worklogs`
--
ALTER TABLE `worklogs`
  ADD CONSTRAINT `worklogs_ibfk_1` FOREIGN KEY (`EmployeeID`) REFERENCES `employees` (`EmployeeID`) ON DELETE SET NULL,
  ADD CONSTRAINT `worklogs_ibfk_2` FOREIGN KEY (`ProjectID`) REFERENCES `projects` (`ProjectID`) ON DELETE SET NULL;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
