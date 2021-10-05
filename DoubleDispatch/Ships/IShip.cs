namespace DoubleDispatch.Ships
{
    public interface IShip
    {
        // A method for receiving each of the expected types of visitor (firing ship)
        // visiting them (firing upon them) (with this implementation in each of the
        // subclasses : enemy.FireUpon(this))
        void FiredUponBy(IShip enemy);

        void FireUpon(ImperialShip enemy);
        void FireUpon(DauntlessCruiser enemy); 
    }
}
