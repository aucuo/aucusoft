using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityDB.Controls.Admin
{
    internal class ControlsManager
    {
        static private Dictionary<string, UserControl> loadedControls = new Dictionary<string, UserControl>();

        public static void ShowControl(string controlKey, Panel hostPanel)
        {
            // Удаление текущего контрола
            hostPanel.Controls.Clear();

            // Загрузка или создание нового контрола
            if (!loadedControls.ContainsKey(controlKey))
            {
                switch (controlKey)
                {
                    case "Teachers":
                        loadedControls[controlKey] = new TeachersControl();
                        break;
                    case "Students":
                        // loadedControls[controlKey] = new StudentsControl();
                        break;
                    case "Specialty":
                        loadedControls[controlKey] = new SpecialtyControl();
                        break;
                    case "Diploma":
                        loadedControls[controlKey] = new DiplomaControl();
                        break;
                    case "Lessons":
                        loadedControls[controlKey] = new LessonsControl();
                        break;
                    case "Deanery":
                        loadedControls[controlKey] = new DeaneryControl();
                        break;
                    case "Departments":
                        loadedControls[controlKey] = new DepartmentsControl();
                        break;
                    case "Groups":
                        loadedControls[controlKey] = new GroupsControl();
                        break;
                    case "Session":
                        //loadedControls[controlKey] = new SessionControl();
                        break;
                    case "Disciplines":
                        loadedControls[controlKey] = new DisciplinesControl();
                        break;
                    case "Research":
                        loadedControls[controlKey] = new ResearchControl();
                        break;
                    case "StudyPlan":
                        loadedControls[controlKey] = new StudyPlanControl();
                        break;
                    default:
                        loadedControls[controlKey] = new TeachersControl();
                        break;
                }
            }

            // Отображение контрола
            UserControl controlToShow = loadedControls[controlKey];
            controlToShow.Dock = DockStyle.Fill;
            hostPanel.Controls.Add(controlToShow);
            controlToShow.Show();
        }
    }
}
