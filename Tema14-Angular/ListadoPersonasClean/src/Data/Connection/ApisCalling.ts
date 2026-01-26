export default class APIAzure{
    private readonly BASE_URL = "1instaciaroberto-afc0hyaueyarb9c5.spaincentral-01.azurewebsites.net"
    public getConnection(): string{
        const url = new URL(this.BASE_URL)
        return url.toString()

    }

    public getDefaultHeaders(): HeadersInit{
        return{
            "Content Type": "application/json"
        }
    }
}