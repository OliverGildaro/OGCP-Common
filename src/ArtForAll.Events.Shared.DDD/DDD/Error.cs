namespace ArtForAll.Shared.Contracts.DDD
{
    public class Error : ValueObject
    {
        private const string separator = "||";
        private string message;
        private string code;
        private string invalidProperty;
        public Error(string message, string code)
        {
            this.message = message;
            this.code = code;
        }

        public string Message => this.message;
        public string Code => this.code;
        public string InvalidProperty => this.invalidProperty;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Code;
        }

        public void SetInvalidProperty(string invalidProperty)
        {
            this.invalidProperty = invalidProperty;
        }

        public string Serialize()
        {
            return $"{Code}{separator}{Message}";
        }

        public static Error Deserialize(string serialized)
        {
            if (serialized == "A non-empty request body is required.")
                return new Error("Value is required", "");

            string[] data = serialized.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);

            if (data.Length < 2)
                throw new Exception($"Invalid error serialization: '{serialized}'");

            return new Error(data[0], data[1]);
        }
    }
}
