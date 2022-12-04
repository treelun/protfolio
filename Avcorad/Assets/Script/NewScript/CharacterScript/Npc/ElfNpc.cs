using System.Collections;

namespace NpcTextnameSpace
{
    public enum TextState
    {
        Yes, No

    }
    [System.Serializable]
    public class ElfNpc
    {
        public string TextString;
        public TextState textState;
    }
}
