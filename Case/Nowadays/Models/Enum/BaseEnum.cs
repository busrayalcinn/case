namespace Nowadays.Models.Enum
{
    public class BaseEnum
    {
        public enum StatusType
        {
            SELECTED_FOR_DEVELOPMENT,
            BLOCKED,
            CONTINUES,
            IN_REVİEW,
            QA,
            READY_FOR_PROD,
            READY_FOR_QA,
            COMPLETED
        }
        public enum TagType
        {
            BE,
            FE,
            QA
        }
    }
}
