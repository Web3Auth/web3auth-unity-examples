# Web3Auth Unity Quick Start Example

[![Web3Auth](https://img.shields.io/badge/Web3Auth_SDK-7.0.2-blue)](https://github.com/Web3Auth/web3auth-unity-sdk/releases/tag/7.0.2)

This example demonstrates email-passwordless authentication and EVM operations with the Web3Auth Unity SDK.

## 🎮 Key Features

- Social login support (Google, Facebook, Twitter, Discord, etc.)
- Email passwordless login
- Secure private key generation and management
- Cross-platform support (iOS, Android, Desktop, WebGL)
- Customizable UI
- Ethereum blockchain integration

## 📋 Prerequisites

- Unity 6.3 LTS (`6000.3.22f1`)
- Web3Auth Unity SDK 7.0.2 (included under `Assets/Plugins/Web3AuthSDK`)
- A [MetaMask Developer Dashboard](https://developer.metamask.io/) Embedded Wallets project
- Platform-specific requirements:
  - iOS: Xcode and an iOS 13.0+ device
  - Android: Android SDK 24+
  - WebGL: Modern browser with Web3 support

## 🚀 Getting Started

1. Clone this example:
```bash
git clone https://github.com/Web3Auth/web3auth-unity-examples.git
cd web3auth-unity-examples/unity-quick-start
```

2. Open in Unity:
   - Launch Unity Hub
   - Click "Add project from disk"
   - Select the `unity-quick-start` directory
   - Open the project

3. Configure Web3Auth:
   - Open `Assets/Web3Auth-Example.unity`
   - Set your Embedded Wallets client ID and network in `Assets/Web3AuthScript.cs`
   - Allowlist `w3aexample://com.web3auth.unityexample/auth` in the dashboard
   - Keep `Assets/Resources/webauth`, the Android intent filter, and the configured redirect URL in sync

## 📚 Example Implementation

The example code in this repository demonstrates:
- Basic Web3Auth initialization and setup
- Social login implementation
- User info retrieval
- Private key management
- Basic Ethereum blockchain interaction

The implementation is in `Assets/Web3AuthScript.cs`. See the [Unity SDK documentation](https://docs.metamask.io/embedded-wallets/sdk/unity/) for configuration and platform setup.

## 🤝 Support

- [Documentation](https://docs.metamask.io/embedded-wallets/sdk/unity/)
- [Builder Hub](https://builder.metamask.io/c/embedded-wallets/5)

## 📝 License

MIT License
