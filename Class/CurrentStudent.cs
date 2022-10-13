using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test.Class
{
    public class CurrentStudent : Person
    {
        public bool IsAdmin { get; set; }//เป็นผู้ดูแลระบบหรือไม่
        public string Email { get; set; }//อีเมลล์ (หากเป็นผู้ดูแลระบบ)
        public string Password { get; set; }//รหัสผ่าน (หากเป็นผู้ดูแลระบบ)
        public string IdStudent { get; set; }//เป็นผู้ดูแลระบบหรือไม่

    }
}
