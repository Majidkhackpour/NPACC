using System.Drawing;
using System.Windows.Forms;

namespace PacketParser.Services
{
    public class ContextMenuSetter : ProfessionalColorTable
    {
        readonly Color _colour = ColorTranslator.FromHtml("#17212b");
        public override Color ToolStripDropDownBackground => _colour;

        public override Color MenuBorder => _colour;

        public override Color MenuItemBorder => Color.White;

        public override Color MenuItemSelected => _colour;
    }
}
