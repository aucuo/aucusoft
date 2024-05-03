using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityDB.Controls.Student
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
                    case "Specialty":
                        loadedControls[controlKey] = new Student.SpecialtyControl();
                        break;
                    case "Diploma":
                        loadedControls[controlKey] = new Student.DiplomaControl();
                        break;
                    case "Lessons":
                        loadedControls[controlKey] = new Student.LessonsControl();
                        break;
                    case "Deanery":
                        loadedControls[controlKey] = new Student.DeaneryControl();
                        break;
                    case "Departments":
                        loadedControls[controlKey] = new Student.DepartmentsControl();
                        break;
                    case "Session":
                        loadedControls[controlKey] = new Student.SessionControl();
                        break;
                    case "StudyPlan":
                        loadedControls[controlKey] = new Student.StudyPlanControl();
                        break;
                    default:
                        loadedControls[controlKey] = new Student.LessonsControl();
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
