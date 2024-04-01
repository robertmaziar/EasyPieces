namespace EasyPieces.Builders
{
    // TODO: See if we can common-ize things
    public abstract class ContentBuilder<TBuilder, TObject>
        where TBuilder : ContentBuilder<TBuilder, TObject>
        where TObject : new()
    {
        protected TObject _contentObject;

        protected ContentBuilder()
        {
            _contentObject = new TObject();
        }

        public TObject Build()
        {
            return _contentObject;
        }
    }
}
