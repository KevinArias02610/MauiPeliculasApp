namespace PeliculasApp.Utilidades
{
    public class FormatLenguajes
    {
        public string FormatearIdioma(string codigo)
        {
            string idioma = codigo switch
            {
                StringConst.ChinoCode => $"{StringConst.Chino} ({StringConst.ChinoCode})",
                StringConst.InglesCode => $"{StringConst.Ingles} ({StringConst.InglesCode})",
                StringConst.NeerlandesCode => $"{StringConst.Neerlandes} ({StringConst.NeerlandesCode})",
                StringConst.FrancesCode => $"{StringConst.Frances} ({StringConst.FrancesCode})",
                StringConst.CoreanoCode => $"{StringConst.Coreano} ({StringConst.CoreanoCode})",
                StringConst.ItalianoCode => $"{StringConst.Italiano} ({StringConst.ItalianoCode})",
                _ => codigo,
            };
            return idioma;
        }
    }
}
