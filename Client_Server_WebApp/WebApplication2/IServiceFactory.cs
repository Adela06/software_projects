//Abstract factory interface
//contract pentru toate fabricile de servicii
public interface IServiceFactory
{
    //metoda responsabilă pentru crearea și returnarea unui serviciu specific
    object CreateService();
}