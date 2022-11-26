namespace StudentManager
{
    public static class Permissions_Model
    {
        public const int STUDENT_ADMIN = 10000000;
        public const int CLASS_ADMIN = 11000000;
        public const int MAJOR_ADMIN = 11100000;
        public const int DEPARTMENT_ADMIN = 11110000;
        public const int ACADEMY_ADMIN = 11111000;
        public const int COURSE_ADMIN = 11111100;
        public const int EVENT_ADMIN = 11111110;
        public const int SUPER_ADMIN = 11111111;

        //Mapper
        public static string Permissions(int Actor_Code)
        {
            switch (Actor_Code)
            {
                case STUDENT_ADMIN:
                    return "学生信息管理员";
                case CLASS_ADMIN:
                    return "班级信息管理员";
                case MAJOR_ADMIN:
                    return "专业信息管理员";
                case DEPARTMENT_ADMIN:
                    return "系部信息管理员";
                case ACADEMY_ADMIN:
                    return "学院信息管理员";
                case COURSE_ADMIN:
                    return "课程信息管理员";
                case EVENT_ADMIN:
                    return "奖惩信息管理员";
                case SUPER_ADMIN:
                    return "超级管理员";
                default:
                    return "未定义";
            }
        }

        public static int ToPermissions(string Actor_Str)
        {
            switch (Actor_Str)
            {
                case "学生信息管理员":
                    return STUDENT_ADMIN;
                case "班级信息管理员":
                    return CLASS_ADMIN;
                case "专业信息管理员":
                    return MAJOR_ADMIN;
                case "系部信息管理员":
                    return DEPARTMENT_ADMIN;
                case "学院信息管理员":
                    return ACADEMY_ADMIN;
                case "课程信息管理员":
                    return COURSE_ADMIN;
                case "奖惩信息管理员":
                    return EVENT_ADMIN;
                case "超级管理员":
                    return SUPER_ADMIN;
                default:
                    return 0;
            }
        }
    }
}
