using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using TMPro;
using Nethereum.Web3;
using Nethereum.Signer;
using Nethereum.Web3.Accounts;
using Newtonsoft.Json.Linq;

public class Web3AuthScript : MonoBehaviour
{
    Web3Auth web3Auth;
    public TextMeshProUGUI console;
    private string userEmail = "";
    private string privateKey;
    private string userInfo;
    private Account account;
    Web3 web3;
    const string rpcURL = "https://1rpc.io/eth";

    // Start is called before the first frame update
    void Start()
    {
        web3Auth = GetComponent<Web3Auth>();
        var JWTLoginConfig = new LoginConfigItem()
        {
            verifier = "w3a-auth0-demo",
            clientId = "hUVVf4SEsZT7syOiL0gLU9hFEtm2gQ6O",
            typeOfLogin = TypeOfLogin.JWT,
        };
        web3Auth.setOptions(new Web3AuthOptions()
        {
            clientId = "BPi5PB_UiIZ-cPz1GtV5i1I2iOSOHuimiXBI0e-Oe_u6X3oVAbCiAZOTEBtTXw4tsluTITPqA8zMsfxIKMjiqNQ",
            redirectUrl = new System.Uri("w3aexample://com.web3auth.unityauth0example"),
            network = Web3Auth.Network.SAPPHIRE_MAINNET,
            loginConfig = new Dictionary<string, LoginConfigItem>
            {
                { "jwt", JWTLoginConfig }
            }
        });
        web3Auth.onLogin += onLogin;
        web3Auth.onLogout += onLogout;
        web3Auth.onMFASetup += onMFASetup;
        web3Auth.onSignResponse += onSignResponse;

        updateConsole("Ready to Login!");
    }

    public void login()
    {
        var selectedProvider = Provider.JWT;

        var options = new LoginParams()
        {
            loginProvider = selectedProvider,
            extraLoginOptions = new ExtraLoginOptions()
            {
                domain = "https://web3auth.au.auth0.com",
                verifierIdField = "sub",
                prompt = Prompt.LOGIN,
            }
        };

        web3Auth.login(options);
    }

    private void onLogin(Web3AuthResponse response)
    {
        userInfo = JsonConvert.SerializeObject(response.userInfo, Formatting.Indented);
        privateKey = response.privKey;
        var newAccount = new Account(privateKey);
        account = newAccount;

        var rpc = new Nethereum.JsonRpc.Client.RpcClient(new Uri(rpcURL));
        web3 = new Web3(account, rpc);

        Debug.Log(JsonConvert.SerializeObject(response, Formatting.Indented));
        updateConsole(JsonConvert.SerializeObject(response, Formatting.Indented));
    }

    public void getUserInfo() {
        if (account == null) {
            Debug.Log("Please Login First");
            updateConsole("Please Login First");
            return;
        }
        Debug.Log(userInfo);
        updateConsole(userInfo);
    }

    public void logout()
    {
        web3Auth.logout();
    }

    private void onLogout()
    {
        privateKey = null;
        userInfo = null;
        account = null;

        Debug.Log("Logged out!");
        updateConsole("Logged out!");
    }


    public void getAccount() {
        if (account == null) {
            Debug.Log("Please Login First");
            updateConsole("Please Login First");
            return;
        }
        Debug.Log(account.Address);
        updateConsole(account.Address);
    }

    public async void getChainId() {
        if (account == null) {
            Debug.Log("Please Login First");
            updateConsole("Please Login First");
            return;
        }
        var chainId = await web3.Net.Version.SendRequestAsync();
        
        Debug.Log(chainId);
        updateConsole(chainId.ToString());
    }

    public void getBalance() {
        if (account == null) {
            Debug.Log("Please Login First");
            updateConsole("Please Login First");
            return;
        }
        var balance = web3.Eth.GetBalance.SendRequestAsync(account.Address).Result.Value;
        
        Debug.Log(balance);
        updateConsole(balance.ToString());
    }

    public void signMessage() {
        if (account == null) {
            Debug.Log("Please Login First");
            updateConsole("Please Login First");
            return;
        }
        var msg = "wee test message 18/09/2017 02:55PM";
        var signer = new EthereumMessageSigner();
        var signature = signer.EncodeUTF8AndSign(msg, new EthECKey(privateKey));
        
        Debug.Log(signature);
        updateConsole(signature.ToString());
    }

    public async void sendTransaction()
    {
        if (account == null)
        {
            Debug.Log("Please Login First");
            updateConsole("Please Login First");
            return;
        }
        try
        {
            var toAddress = "0x2E464670992574A613f10F7682D5057fB507Cc21";
            var transaction = await web3.TransactionManager.SendTransactionAsync(account.Address, toAddress, new Nethereum.Hex.HexTypes.HexBigInteger(1));

            Debug.Log(transaction);
            updateConsole(transaction.ToString());

        } catch(Exception e)
        {
            Debug.Log(e);
            updateConsole(e.ToString());
        }
        
    }

    public void enableMFA()
    {
        var selectedProvider = Provider.JWT;

        var options = new LoginParams()
        {
            loginProvider = selectedProvider,
            extraLoginOptions = new ExtraLoginOptions()
            {
                domain = "https://web3auth.au.auth0.com",
                verifierIdField = "sub",
                prompt = Prompt.LOGIN,
            }
        };

        web3Auth.enableMFA(options);
    }

    private void onMFASetup(bool response)
    {
        Debug.Log("MFA Setup: " + response);
    }

    public void launchWalletServices()
    {
        var chainConfig = new ChainConfig()
        {
            chainId = "0x1",
            rpcTarget = rpcURL,
            ticker = "ETH",
            chainNamespace = Web3Auth.ChainNamespace.EIP155
        };
        web3Auth.launchWalletServices(chainConfig);
    }

    public void PopupSignMessageUI()
    {
        var chainConfig = new ChainConfig()
        {
            chainId = "0xaa36a7",
            rpcTarget = "https://1rpc.io/sepolia",
            ticker = "ETH",
            chainNamespace = Web3Auth.ChainNamespace.EIP155
        };

        JArray paramsArray = new JArray
        {
             "Hello World",
             account.Address,
             "Android"
        };

        web3Auth.request(chainConfig, "personal_sign", paramsArray);
    }


    private void onSignResponse(SignResponse signResponse)

    {
        Debug.Log("Retrieved SignResponse: " + signResponse);
        updateConsole("Retrieved SignResponse: " + signResponse);
    }


    public void updateConsole(string message){
        console.text = message;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}