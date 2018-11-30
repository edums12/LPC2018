using System.ComponentModel;

namespace Associados.Domain
{
    public enum EnumEstadosCivis
    {
        [Description("Solteiro")]
        Solteiro = 1,

        [Description("Casado")]
        Casado = 2,

        [Description("Viúvo")]
        Viuvo = 3,

        [Description("Separado Judicialmente")]
        SeparadoJudicialmente = 4,

        [Description("Divorciado")]
        Divorciado = 5

    }
}