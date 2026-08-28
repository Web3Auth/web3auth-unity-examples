# Web3Auth Unity Grouped Auth Connection Example

[![Web3Auth](https://img.shields.io/badge/Web3Auth_SDK-7.0.2-blue)](https://github.com/Web3Auth/web3auth-unity-sdk/releases/tag/7.0.2)

This example demonstrates a grouped auth connection (formerly aggregate verifier), which combines multiple authentication providers while maintaining one wallet for the same user identity.

## 🎮 Key Features

- Multiple authentication provider support
- Single private key across providers
- Seamless provider switching
- Supported providers in this example:
  - Google OAuth
  - Facebook OAuth
  - GitHub through Auth0
- Sub-verifier configuration
- Unified user experience

## 📋 Prerequisites

- Unity 6.3 LTS (`6000.3.22f1`)
- Web3Auth Unity SDK 7.0.2 (included under `Assets/Plugins/Web3AuthSDK`)
- A [MetaMask Developer Dashboard](https://developer.metamask.io/) Embedded Wallets project
- Provider accounts:
  - Google Cloud Console Account
  - Auth0 Account
  - GitHub Developer Account
- Platform-specific requirements:
  - iOS: Xcode and an iOS 13.0+ device
  - Android: Android SDK 24+
  - WebGL: Modern browser with Web3 support

## 🚀 Getting Started

1. Clone this example:
```bash
git clone https://github.com/Web3Auth/web3auth-unity-examples.git
cd web3auth-unity-examples/unity-aggregate-verifier-example
```

2. Open in Unity:
   - Launch Unity Hub
   - Click "Add project from disk"
   - Select the `unity-aggregate-verifier-example` directory
   - Open the project

3. Configure Web3Auth and Providers:
   - Create a grouped auth connection and its provider connections in the Embedded Wallets dashboard
   - Open `Assets/Web3Auth-Example.unity`
   - Configure the client ID, grouped connection ID, sub-connection IDs, and OAuth client IDs in `Assets/Web3AuthScript.cs`
   - Ensure every provider uses the same user identifier semantics
   - Allowlist `w3aexample://com.web3auth.unityaggregateexample/auth` in the dashboard

## 🤝 Support

- [Unity SDK Documentation](https://docs.metamask.io/embedded-wallets/sdk/unity/)
- [Authentication Documentation](https://docs.metamask.io/embedded-wallets/authentication/)
- [Builder Hub](https://builder.metamask.io/c/embedded-wallets/5)

## 📝 License

MIT License 