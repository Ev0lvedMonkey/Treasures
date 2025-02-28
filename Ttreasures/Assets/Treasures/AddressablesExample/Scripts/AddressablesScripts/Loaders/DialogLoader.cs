
using System.Threading.Tasks;

internal class DialogLoader : LocalAssetsLoader
{
    public enum DialogLoadKeys
    {
        ADialog1, ADialog2, ADialog3
    }

    public Task<ADialog> Load(DialogLoadKeys loadKeys)
    {
        Unload();
        return LoadInternal<ADialog>($"{loadKeys}");
    }

    public void Unload()
    {
        UnloadInternal(); 
    }

}

