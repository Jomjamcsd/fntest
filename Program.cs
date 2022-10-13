using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using test.Class;

namespace test
{
    class Program
    {
        private static List<CurrentStudent> _listCurrentStudent = new List<CurrentStudent>();
        private static List<Student> _listStudent = new List<Student>();
        private static List<Teacher> _listTeacher = new List<Teacher>();

        private static string _listCult = "พุทธ,คริสต์,อิสลาม,อื่นๆ";
        private static string _listLvOfStudent = "มัธยมศึกษาปีที่4,มัธยมศึกษาปีที่5,มัธยมศึกษาปีที่6";
        private static string _listTitle = "นาย,นาง,นางสาว";
        private static string _listPosition = "คณบดี,หัวหน้าภาควิชา,อาจารย์ประจำ";
        private static string _fristNameAndLastName = string.Empty;

        static void Main(string[] args)
        {
            if (!string.IsNullOrEmpty(_fristNameAndLastName))
            {
                Console.WriteLine("Login : " + _fristNameAndLastName);
            }

            string selectedMenu = Methods1_1();
            string emailAndPassword = string.Empty;

            switch (selectedMenu)
            {
                case "1":
                    Methods1_2(); //เมนูลงทะเบียนเข้าร่วมงาน
                    break;
                case "2":
                    Methods1_4(); //เมนูแสดงสถิติผู้เข้าร่วมงาน
                    break;
                case "3":
                    Methods1_3(); //เมนูเข้าสู่ระบบ
                    break;
                case "4":
                    Methods1_5(); //เมนูแสดงข้อมูลนักศึกษาปัจจุบันที่เข้าร่วมโครงการทั้งหมด
                    break;
                case "5":
                    Methods1_6(); //เมนูแสดงข้อมูลนักศึกษาปัจจุบันที่เข้าร่วมโครงการทั้งหมด
                    break;
                case "6":
                    Methods1_7(); //เมนูแสดงข้อมูลอาจารย์ที่เข้าร่วมโครงการทั้งหมด
                    break;
                default:
                    break;
            }



            Console.ReadLine();
        }

        /// <summary>
        /// เมนูลงทะเบียนเข้าร่วมงาน
        /// </summary>
        /// <returns></returns>
        private static string Methods1_1()
        {
            Console.WriteLine("กรุณาเลือกเมนู");//
            Console.WriteLine("1.เมนูลงทะเบียนเข้าร่วมงาน");//
            Console.WriteLine("2.เมนูแสดงสถิติผู้เข้าร่วมงาน");//
            Console.WriteLine("3.เมนูเข้าสู่ระบบ");//
            Console.WriteLine("4.เมนูแสดงข้อมูลนักศึกษาปัจจุบันที่เข้าร่วมโครงการทั้งหมด");//
            Console.WriteLine("5.เมนูแสดงข้อมูลนักเรียนที่เข้าร่วมโครงการทั้งหมด");//
            Console.WriteLine("6.เมนูแสดงข้อมูลอาจารย์ที่เข้าร่วมโครงการทั้งหมด");//

            string selectedMenu = InputFixValue("1,2,3,4,5,6");
            return selectedMenu;
        }

        /// <summary>
        /// เมนูลงทะเบียนเข้าร่วมงาน
        /// </summary>
        /// <returns></returns>
        private static void Methods1_2()
        {
            Console.WriteLine("กรุณาเลือกประเภทผู้ลงทะเบียน");
            Console.WriteLine("1.นักศึกษาปัจจุบัน");
            Console.WriteLine("2.นักเรียน");
            Console.WriteLine("3.อาจารย์");
            string selectedMenu = InputFixValue("1,2,3");
            Person entityBase = null;
            switch (selectedMenu)
            {
                case "1":
                    CurrentStudent currentStudent = new CurrentStudent();
                    Console.WriteLine("กรุณากรอกข้อมูล คำนำหน้า");
                    currentStudent.TitleName = SelectedList(_listTitle);
                    Console.WriteLine("กรุณากรอกข้อมูล ชื่อ");
                    currentStudent.FristName = Console.ReadLine();
                    Console.WriteLine("กรุณากรอกข้อมูล นามสกุล");
                    currentStudent.LastName = Console.ReadLine();
                    ValidateUser(currentStudent);
                    Console.WriteLine("กรุณากรอกข้อมูล รหัสนักศึกษา");
                    currentStudent.IdStudent = Console.ReadLine();
                    Console.WriteLine("กรุณากรอกข้อมูล อายุ");
                    currentStudent.Age = Console.ReadLine();
                    Console.WriteLine("กรุณากรอกข้อมูล สิ่งที่แพ้");
                    currentStudent.ItemLose = Console.ReadLine();
                    Console.WriteLine("กรุณากรอกข้อมูล ศาสนา");
                    currentStudent.Cult = SelectedList(_listCult);
                    Console.WriteLine("เป็นผู้ดูแลระบบหรือไม่");
                    currentStudent.IsAdmin = SelectedYorN();
                    if (currentStudent.IsAdmin)
                    {
                        Console.WriteLine("กรุณากรอกข้อมูล Email");
                        currentStudent.Email = Console.ReadLine();
                        ValidateEmail(currentStudent.Email);
                        Console.WriteLine("กรุณากรอกข้อมูล Password");
                        currentStudent.Password = Console.ReadLine();
                    }
                    _listCurrentStudent.Add(currentStudent);
                    entityBase = currentStudent;
                    break;
                case "2":
                    Student student = new Student();
                    Console.WriteLine("กรุณากรอกข้อมูล คำนำหน้า");
                    student.TitleName = SelectedList(_listTitle);
                    Console.WriteLine("กรุณากรอกข้อมูล ชื่อ");
                    student.FristName = Console.ReadLine();
                    Console.WriteLine("กรุณากรอกข้อมูล นามสกุล");
                    student.LastName = Console.ReadLine();
                    ValidateUser(student);
                    Console.WriteLine("กรุณากรอกข้อมูล อายุ");
                    student.Age = Console.ReadLine();
                    Console.WriteLine("กรุณากรอกข้อมูล ระดับการศึกษา");
                    student.LevelOfEducation = SelectedList(_listLvOfStudent);
                    Console.WriteLine("กรุณากรอกข้อมูล สิ่งที่แพ้");
                    student.ItemLose = Console.ReadLine();
                    Console.WriteLine("กรุณากรอกข้อมูล ศาสนา");
                    student.Cult = SelectedList(_listCult);
                    Console.WriteLine("กรุณากรอกข้อมูล โรงเรียน");
                    student.SchoolName = Console.ReadLine();
                    _listStudent.Add(student);
                    entityBase = student;
                    break;
                case "3":
                    Teacher teacher = new Teacher();
                    Console.WriteLine("กรุณากรอกข้อมูล คำนำหน้า");
                    teacher.TitleName = SelectedList(_listTitle);
                    Console.WriteLine("กรุณากรอกข้อมูล ชื่อ");
                    teacher.FristName = Console.ReadLine();
                    Console.WriteLine("กรุณากรอกข้อมูล นามสกุล");
                    teacher.LastName = Console.ReadLine();
                    ValidateUser(teacher);
                    Console.WriteLine("กรุณากรอกข้อมูล อายุ");
                    teacher.Age = Console.ReadLine();
                    Console.WriteLine("กรุณากรอกข้อมูล ตำแหน่ง");
                    teacher.Position = SelectedList(_listPosition);
                    Console.WriteLine("กรุณากรอกข้อมูล สิ่งที่แพ้");
                    teacher.ItemLose = Console.ReadLine();
                    Console.WriteLine("กรุณากรอกข้อมูล ศาสนา");
                    teacher.Cult = SelectedList(_listCult);
                    Console.WriteLine("นำรถยนต์มาเข้าร่วมโครงการหรือไม่");
                    teacher.IsUseCar = SelectedYorN();
                    if (teacher.IsUseCar)
                    {
                        Console.WriteLine("กรุณากรอกทะเบียนรถ");
                        teacher.CarNo = Console.ReadLine();
                    }
                    Console.WriteLine("เป็นผู้ดูแลระบบหรือไม่");
                    teacher.IsAdmin = SelectedYorN();
                    if (teacher.IsAdmin)
                    {
                        Console.WriteLine("กรุณากรอกข้อมูล Email");
                        teacher.Email = Console.ReadLine();
                        ValidateEmail(teacher.Email);
                        Console.WriteLine("กรุณากรอกข้อมูล Password");
                        teacher.Password = Console.ReadLine();
                    }
                    _listTeacher.Add(teacher);
                    entityBase = teacher;
                    break;
                default:
                    break;
            }


            RegisterSuccess(entityBase, selectedMenu);
            Main(null);
        }

        private static void RegisterSuccess(Person entityBase, string typeRegister)
        {
            Console.Clear();
            string typeName = string.Empty;
            switch (typeRegister)
            {
                case "1":
                    typeName = "นักศึกษาปัจจุบัน";
                    break;
                case "2":
                    typeName = "นักเรียน";
                    break;
                case "3":
                    typeName = "อาจารย์";
                    break;
                default:
                    break;
            }
            Console.WriteLine("ลงทะเบียน {0} {1} {2} {3} สำเร็จ", typeName, entityBase.TitleName, entityBase.FristName, entityBase.LastName);
        }

        private static void ValidateUser(Person entityBase)
        {
            bool isUserAlready = false;
            foreach (CurrentStudent entity in _listCurrentStudent)
            {
                if (entity.TitleName == entityBase.TitleName && entity.FristName == entityBase.FristName && entity.LastName == entityBase.LastName)
                {
                    isUserAlready = true;
                    break;
                }

            }

            foreach (Student entity in _listStudent)
            {
                if (entity.TitleName == entityBase.TitleName && entity.FristName == entityBase.FristName && entity.LastName == entityBase.LastName)
                {
                    isUserAlready = true;
                    break;
                }

            }

            foreach (Teacher entity in _listTeacher)
            {
                if (entity.TitleName == entityBase.TitleName && entity.FristName == entityBase.FristName && entity.LastName == entityBase.LastName)
                {
                    isUserAlready = true;
                    break;
                }

            }

            if (isUserAlready)
            {
                Console.Clear();
                Console.WriteLine("User is already registered. Please try again.");
                Methods1_2();
            }
        }

        private static void ValidateEmail(string email)
        {
            bool isEmailAlready = false;
            foreach (CurrentStudent entity in _listCurrentStudent)
            {
                if (entity.Email == email)
                {
                    isEmailAlready = true;
                    break;
                }

            }

            foreach (Student entity in _listStudent)
            {
                if (entity.Email == email)
                {
                    isEmailAlready = true;
                    break;
                }

            }

            foreach (Teacher entity in _listTeacher)
            {
                if (entity.Email == email)
                {
                    isEmailAlready = true;
                    break;
                }

            }

            if (!string.IsNullOrEmpty(email) && email.ToLower() == "exit")
            {
                isEmailAlready = true;
            }

            if (isEmailAlready)
            {
                Console.Clear();
                Console.WriteLine("Incorrect email or password. Please try again.");
                Methods1_2();
            }
        }

        private static string SelectedList(string listText)
        {
            string result = string.Empty;

            string[] list = listText.Split(',');
            string valueFix = string.Empty;
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(i + 1 + "." + list[i]);
                valueFix += Convert.ToString(i + 1) + ",";
            }
            result = InputFixValue(valueFix);
            int resultNum = Convert.ToInt16(result);
            result = list[resultNum - 1];
            return result;
        }

        private static bool SelectedYorN()
        {
            bool result = false;
            Console.WriteLine("ระบุ Y หรือ N");
            string resultText = InputFixValue("Y,N,y,n");

            switch (resultText.ToLower())
            {
                case "y":
                    result = true;
                    break;
                case "n":
                    result = false;
                    break;
                default:
                    break;
            }

            return result;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static void Methods1_3()
        {
            bool isLogin = false;
            string email = string.Empty;
            string password = string.Empty;
            bool isExit = false;
            while (!isLogin)
            {
                Console.WriteLine("Email");
                email = Console.ReadLine();
                if (email.ToLower() == "exit")
                {
                    Console.Clear();
                    isExit = true;
                    break;
                }
                Console.WriteLine("Password");
                password = Console.ReadLine();


                foreach (CurrentStudent entity in _listCurrentStudent)
                {
                    if (entity.Email == email && entity.Password == password)
                    {
                        _fristNameAndLastName = entity.FristName + "" + entity.LastName;
                        isLogin = true;
                        Console.Clear();
                        // Go to 1.1
                        break;
                    }
                }

                foreach (Teacher entity in _listTeacher)
                {
                    if (entity.Email == email && entity.Password == password)
                    {
                        _fristNameAndLastName = entity.FristName + "" + entity.LastName;
                        isLogin = true;
                        Console.Clear();
                        // Go to 1.1


                        break;
                    }
                }

                if (!isLogin)
                {
                    Console.WriteLine("Incorrect email or password. Please try again");
                }
                else
                {
                    Console.WriteLine("Login Success");
                    Main(null);
                }
            }

            if (isExit)
            {
                Main(null);// Go to 1.1
            }
        }

        private static void Methods1_4()
        {
            Console.Clear();
            Console.WriteLine("จำนวนอาจารย์ที่ลงทะเบียนทั้งหมด : " + _listTeacher.Count + " คน");
            Console.WriteLine("จำนวนนักเรียนที่ลงทะเบียนทั้งหมด : " + _listStudent.Count + " คน");
            Console.WriteLine("จำนวนนักศึกษาปัจจุบันที่ลงทะเบียนทั้งหมด : " + _listCurrentStudent.Count + " คน");
            int m4 = 0;
            int m5 = 0;
            int m6 = 0;
            foreach (Student entity in _listStudent)
            {
                //    private static string _listLvOfStudent = "มัธยมศึกษาปีที่4,มัธยมศึกษาปีที่5,มัธยมศึกษาปีที่6";
                switch (entity.LevelOfEducation)
                {
                    case "มัธยมศึกษาปีที่4":
                        m4 += 1;
                        break;

                    case "มัธยมศึกษาปีที่5":
                        m5 += 1;
                        break;

                    case "มัธยมศึกษาปีที่6":
                        m6 += 1;
                        break;

                    default:
                        break;
                }
            }
            Console.WriteLine("จำนวนนักเรียนเฉพาะระดับชั้นมัธยมศึกษาปีที่ 4 ที่ลงทะเบียนทั้งหมด " + m4 + " คน");
            Console.WriteLine("จำนวนนักเรียนเฉพาะระดับชั้นมัธยมศึกษาปีที่ 5 ที่ลงทะเบียนทั้งหมด " + m5 + " คน");
            Console.WriteLine("จำนวนนักเรียนเฉพาะระดับชั้นมัธยมศึกษาปีที่ 6 ที่ลงทะเบียนทั้งหมด " + m6 + " คน");

            Console.ReadLine();
            Console.Clear();
            Main(null);
        }

        private static void Methods1_5()
        {
            Console.Clear();
            if (_listCurrentStudent.Count > 0)
            {
                foreach (CurrentStudent entity in _listCurrentStudent)
                {
                    Console.WriteLine(string.Format("{0} {1} {2}", entity.TitleName, entity.FristName, entity.LastName));
                }
            }
            else
            {
                Console.WriteLine("ไม่พบข้อมูลนักเรียนปัจจุบันในระบบ");
            }


            Console.ReadLine();
            Console.Clear();
            Main(null);
        }

        private static void Methods1_6()
        {
            Console.Clear();

            int countTotal = 0;
            countTotal += _listCurrentStudent.Count;
            countTotal += _listStudent.Count;

            if (countTotal > 0)
            {
                foreach (CurrentStudent entity in _listCurrentStudent)
                {
                    Console.WriteLine(string.Format("{0} {1} {2}", entity.TitleName, entity.FristName, entity.LastName));
                }

                foreach (Student entity in _listStudent)
                {
                    Console.WriteLine(string.Format("{0} {1} {2}", entity.TitleName, entity.FristName, entity.LastName));
                }
            }
            else
            {
                Console.WriteLine("ไม่พบข้อมูลนักเรียนทั้งหมดในระบบ");
            }



            Console.ReadLine();
            Console.Clear();
            Main(null);
        }

        private static void Methods1_7()
        {
            Console.Clear();

            if (_listTeacher.Count > 0)
            {
                foreach (Teacher entity in _listTeacher)
                {
                    Console.WriteLine(string.Format("{0} {1} {2}", entity.TitleName, entity.FristName, entity.LastName));
                }
            }
            else
            {
                Console.WriteLine("ไม่พบข้อมูลอาจารย์ในระบบ");
            }
 

            Console.ReadLine();
            Console.Clear();
            Main(null);
        }




        private static string InputFixValue(string fixValue)
        {
            string result = Console.ReadLine();
            string[] fixValueArr = fixValue.Split(',');
            bool isFixValue = false;

            for (int i = 0; i < fixValueArr.Length; i++)
            {
                if (fixValueArr[i] == result)
                {
                    isFixValue = true;
                    return result;
                }
            }
            if (!isFixValue)
            {
                Console.WriteLine("กรุณาเลือกข้อมูลให้ถูกต้อง");
                return InputFixValue(fixValue);
            }
            return result;
        }

    }



}
