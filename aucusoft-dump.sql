INSERT INTO `managers` (`ManagerID`, `Name`, `Position`) VALUES
(1, 'Alexey Petrov', 'Senior Project Manager'),
(2, 'Maria Ivanova', 'Project Manager'),
(3, 'Igor Sidorov', 'IT Manager'),
(4, 'Elena Popova', 'Development Manager'),
(5, 'Dmitry Kuznetsov', 'Product Manager');

INSERT INTO `clients` (`ClientID`, `Name`, `Industry`, `ContactPerson`, `Email`, `Phone`) VALUES
(1, 'test', 'test', 'test', 'test', 'test'),
(2, 'Beta LLC', 'Finance', 'Jane Smith', 'janesmith@betallc.com', '80293284224'),
(3, 'Gamma Inc', 'Healthcare', 'Mike Brown', 'mikebrown@gammainc.com', '80293284224'),
(4, 'Delta Technologies', 'Education', 'Susan Clark', 'susanclark@deltatech.com', '80293284224'),
(5, 'Epsilon Services', 'Retail', 'Alex Johnson', 'alexjohnson@epsilonservices.com', '80293284224'),
(6, 'Aucusoft', 'Finance', 'Egor Shikovets', 'Egor Shikovets@example.com', '80293284224'),
(15, 'test2', 'test2', 'test2', 'test2', 'test2');

INSERT INTO `taskstatuses` (`StatusID`, `Name`) VALUES
(1, 'Not Started'),
(2, 'In Progress'),
(3, 'Completed'),
(4, 'On Hold'),
(5, 'Cancelled');

INSERT INTO `technologies` (`TechnologyID`, `Name`, `Description`) VALUES
(1, 'Java', 'Язык программирования для разработки серверной части'),
(2, 'React', 'Библиотека для создания пользовательских интерфейсов'),
(3, 'Docker', 'Платформа для контейнеризации приложений'),
(4, 'Kubernetes', 'Система управления контейнеризированными приложениями'),
(5, 'TensorFlow', 'Открытая библиотека для машинного обучения');

INSERT INTO `departments` (`DepartmentID`, `Name`, `ManagerID`) VALUES
(1, 'Development', 4),
(2, 'Sales', 1),
(3, 'HR', 3),
(4, 'Marketing', 2),
(5, 'Finance', 5),

INSERT INTO `positions` (`PositionID`, `Title`, `SalaryGrade`) VALUES
(1, 'Software Developer', 2),
(2, 'Project Manager', 1),
(3, 'Quality Assurance Engineer', 3),
(4, 'UI/UX Designer', 4),
(5, 'System Analyst', 1);

INSERT INTO `employees` (`EmployeeID`, `Name`, `PositionID`, `DepartmentID`, `Email`, `Phone`) VALUES
(1, 'Ivan Ivanov', 1, 1, 'new_email@example.com', '1234567890'),
(2, 'Petr Petrov', 2, 2, 'petrov@example.com', '0987654321'),
(3, 'Sidor Sidorov', 3, 3, 'sidorov@example.com', '1122334455'),
(4, 'Anna Annanova', 4, 4, 'annanova@example.com', '2233445566'),
(5, 'Olga Olganova', 5, 5, 'olganova@example.com', '3344556677');

INSERT INTO `projects` (`ProjectID`, `Name`, `StartDate`, `EndDate`, `Budget`, `ClientID`, `ProjectManagerID`) VALUES
(1, 'Project Alpha', '2024-02-01', '2024-02-21', '121000.00', 1, 2),
(2, 'Project Beta', '2024-03-01', '2024-02-21', '192500.00', 2, 2),
(3, 'Project Gamma', '2024-04-01', '2024-02-21', '253000.00', 3, 2),
(4, 'Project Delta', '2024-05-01', '2024-11-01', '313500.00', 4, 2),
(5, 'Project Epsilon', '2024-06-01', '2024-06-15', '374000.00', 5, 2),
(6, 'New Project', '2024-01-01', '2024-12-31', '121000.00', 1, 1),
(7, 'New Project', '2024-01-01', '2024-12-31', '121000.00', 2, 1),
(8, 'New Project', '2024-01-01', '2024-12-31', '121000.00', 3, 1),
(9, 'New Project', '2024-01-01', '2024-12-31', '121000.00', 4, 1),
(10, 'New Project', '2024-01-01', '2024-12-31', '121000.00', 5, 1),
(11, 'test11', NULL, NULL, '999999.00', NULL, NULL);

INSERT INTO `projectdocuments` (`DocumentID`, `ProjectID`, `Title`, `DocumentPath`, `CreationDate`) VALUES
(1, 1, 'Техническое задание', '/docs/project1/specification.pdf', '2024-02-15'),
(2, 1, 'План проекта', '/docs/project1/plan.pdf', '2024-02-20'),
(3, 2, 'Архитектура системы', '/docs/project2/architecture.pdf', '2024-03-01'),
(4, 3, 'Тестовый план', '/docs/project3/test_plan.pdf', '2024-03-15'),
(5, 4, 'Пользовательская документация', '/docs/project4/user_guide.pdf', '2024-04-01');

----------------------
INSERT INTO `clientfeedback` (`FeedbackID`, `ProjectID`, `ClientID`, `Date`, `Text`) VALUES
(1, 1, 1, '2024-02-15', 'Updated feedback text due to client review.'),
(2, 2, 2, '2024-03-15', 'The project was delivered on time, but there were some issues with the initial deployment.'),
(3, 3, 3, '2024-04-15', 'Excellent communication and project management.'),
(6, 1, 5, '2024-02-15', 'Updated feedback text due to client review.'),
(7, 1, 1, '2024-02-15', 'Updated feedback text due to client review.'),
(8, 4, 2, '2024-07-01', 'This is a newly added feedback.');

INSERT INTO `tasks` (`TaskID`, `ProjectID`, `AssignedTo`, `Description`, `StartDate`, `EndDate`, `StatusID`) VALUES
(1, 1, 1, 'Database design', '2024-02-01', '2024-02-10', 3),
(2, 1, 2, 'API development', '2024-02-11', '2024-02-20', 2),
(3, 2, 1, 'Frontend setup', '2024-02-05', '2024-02-15', 2),
(4, 2, 3, 'Backend logic', '2024-02-16', '2024-02-25', 1),
(5, 3, 2, 'Testing', '2024-02-26', '2024-03-07', 1);

INSERT INTO `employeetasks` (`EmployeeTaskID`, `TaskID`, `EmployeeID`, `TimeSpent`, `Date`) VALUES
(1, 1, 1, 8, '2024-02-01'),
(2, 2, 2, 6, '2024-02-12'),
(3, 3, 1, 7, '2024-02-06'),
(4, 4, 3, 8, '2024-02-17'),
(5, 5, 2, 5, '2024-02-27');

INSERT INTO `meetings` (`MeetingID`, `ProjectID`, `MeetingDate`, `Agenda`) VALUES
(3, 2, '2024-04-05', 'Промежуточный отчет'),
(4, 3, '2024-04-20', 'Тестирование продукта'),
(5, 4, '2024-05-10', 'Запуск проекта');

INSERT INTO `projecttechnologies` (`ProjectTechnologyID`, `ProjectID`, `TechnologyID`) VALUES
(1, 1, 1),
(2, 1, 2),
(3, 2, 3),
(4, 3, 4),
(5, 4, 5);

INSERT INTO `worklogs` (`WorkLogID`, `EmployeeID`, `ProjectID`, `HoursWorked`, `Date`) VALUES
(1, 1, 1, 8, '2024-02-15'),
(2, 2, 1, 6, '2024-02-16'),
(3, 3, 2, 7, '2024-02-17'),
(4, 4, 2, 8, '2024-02-18'),
(5, 5, 3, 5, '2024-02-19');