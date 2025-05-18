# Web3Auth Unity Aggregate Verifier Example

[![Web3Auth](https://img.shields.io/badge/Web3Auth-SDK-blue)](https://web3auth.io/docs/sdk/pnp/unity)
[![Web3Auth](https://img.shields.io/badge/Web3Auth-Community-cyan)](https://community.web3auth.io)

This example demonstrates how to use Web3Auth's Aggregate Verifier feature in a Unity application. Aggregate Verifiers allow you to combine multiple authentication methods and providers while maintaining a single key for the user across all of them.

## 🎮 Key Features

- Multiple authentication provider support
- Single private key across providers
- Seamless provider switching
- Supported providers in this example:
  - Google OAuth
  - Auth0 Email Passwordless
  - GitHub OAuth
- Sub-verifier configuration
- Unified user experience

## 📋 Prerequisites

- Unity 2020.3 LTS or higher
- .NET 4.x or higher
- Web3Auth Dashboard Account ([Sign up here](https://dashboard.web3auth.io))
- Provider accounts:
  - Google Cloud Console Account
  - Auth0 Account
  - GitHub Developer Account
- Platform-specific requirements:
  - iOS: Xcode 13.0+, iOS 13.0+ device
  - Android: Android Studio, Android SDK 21+
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
   - Follow the [Web3Auth Unity SDK Setup Guide](https://web3auth.io/docs/sdk/pnp/unity/installation) for installation
   - Follow the [Aggregate Verifier Setup Guide](https://web3auth.io/docs/auth-provider-setup/aggregate-verifier) for provider configuration
   - Get your Client ID from [Web3Auth Dashboard](https://dashboard.web3auth.io)
   - Open the demo scene in `Assets/Scenes/Web3AuthDemo.unity`
   - Select the Web3Auth game object
   - Configure with your Web3Auth and provider credentials

## 🤝 Support

- [Web3Auth Documentation](https://web3auth.io/docs/sdk/pnp/unity)
- [Aggregate Verifier Guide](https://web3auth.io/docs/auth-provider-setup/aggregate-verifier)
- [Discord](https://discord.gg/web3auth)
- [Guides](https://web3auth.io/docs/guides)

## 📝 License

MIT License 