namespace Pedrera.Core.Mvc
{
    public interface IAppSettings
    {
        string Get(string name, string defaultValue);
        bool Get(string name, bool defaultValue);
        T Get<T>(string name, T defaultValue);
    }
}
