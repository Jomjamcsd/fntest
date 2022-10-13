using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test.Class
{
    class Teacher : Person
    {
        public bool IsUseCar { get; set; }//นำรถยนต์มาเข้าร่วมโครงการหรือไม่
        public string Position { get; set; }// ตำแหน่ง
        public bool IsAdmin { get; set; }//เป็นผู้ดูแลระบบหรือไม่
        public string Password { get; set; }//รหัสผ่าน (หากเป็นผู้ดูแลระบบ)
        public string CarNo { get; set; }//ทะเบียนรถ

    }
}
