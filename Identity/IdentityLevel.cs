using p1.Controllers;

namespace p1.Identity
{

    /*The less ID, the more access
    * default :
    * 
    *   Adminastrator - 0
    *   Moderator - 1
    *   Supporter - 2
    *   User - 3
    */
    public class IdentityLevel
    {
        public int accessLevel { get; set; }
        public string roleName { get; set; }
        public string policyName { get; set; }

        public IdentityLevel(int _accessLevel , string _roleName , string _policyName)
        {
            _accessLevel = accessLevel;
            _roleName = roleName;
            _policyName = policyName;
        }

    }
    
}
