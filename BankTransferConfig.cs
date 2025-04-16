using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

public class BankTransferConfig
{
	private BankTransferConfig config;
	private const string filePAth = "bank_transfer_config";

	public string lang { get; set; } = "en";
	public int threshold { get; set; } = 25000000;
	public int low_fee { get; set; } = 6500;
    public int high_fee { get; set; } = 15000;
	public int methods { get; set; } = ["RTO(real-time),"SKN","RTGS","BI FAST"];
	public string en { get; set; } = "yes";
	public string id { get; set; } = "ya";

	public BankTransferConfig()
	{
		try
		{
			ReadConfigFile();
		}
		catch
		{
			SetDefault();
			WriteConfigFile();
		}

	}
	public void SetDefault()
	{
		config = new BankTransferConfig();
		config.lang = "en";
		Tranfer transfer = new(25000000, 6500, 15000);
		config.transfer = transfer;
		List<String> Isi = new List<String>();
		Isi.Add("RTO(real-time)");
		Isi.Add("SKN");
		Isi.Add("RTGS");
		Isi.Add("BI FAST");
		Confirmation confirm = new Confirmation();
		confirm.en = "yes"
		confirm.id = "ya"
		config.confirm = confirm;
    }
	public void ReadConfigFile()
	{
		string json = File.ReadAllText(filePath);
		config = JsonSerializer.Deserialize<BankTranferConfig>(json);
	}
	public void WriteConfigFile()
	{
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true
        };
        String jsonString = JsonSerializer.Serialize(config, options);
        File.WriteAllText(filePath, jsonString);
    }
	public class config()
	{
		public String lang { get; set; };
        public Tranfer transfer { get; set; }
        public List<String> methods { get; set; }
		public Confirmation confirmation { get; set; }
		public config(Sting lang, Transfer transfer, List<String> methods, Confirmation confirmation)
		{
			this.lang = new lang;
			this.transfer = new transfer;
			this.methods = new methods;
			this.confirmation = new confirmation;
		}

    }
    static void Main()
    {
        BankTransferConfig bank = new BankTransferConfig();
        if (bank.config.lang == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer: ");

        }
        else
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer: ");
        }

    }

}
