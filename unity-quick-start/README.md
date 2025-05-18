# Web3Auth Unity Quick Start Example

[![Web3Auth](https://img.shields.io/badge/Web3Auth-SDK-blue)](https://web3auth.io/docs/sdk/pnp/unity)
[![Web3Auth](https://img.shields.io/badge/Web3Auth-Community-cyan)](https://community.web3auth.io)

This example demonstrates how to integrate Web3Auth's Plug and Play SDK into a Unity application. Web3Auth provides a seamless authentication solution that combines the security of blockchain wallets with the convenience of social logins.

## 🎮 Key Features

- Social login support (Google, Facebook, Twitter, Discord, etc.)
- Email passwordless login
- Secure private key generation and management
- Cross-platform support (iOS, Android, Desktop, WebGL)
- Customizable UI
- Ethereum blockchain integration

## 📋 Prerequisites

- Unity 2020.3 LTS or higher
- .NET 4.x or higher
- Web3Auth Dashboard Account ([Sign up here](https://dashboard.web3auth.io))
- Platform-specific requirements:
  - iOS: Xcode 13.0+, iOS 13.0+ device
  - Android: Android Studio, Android SDK 21+
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
   - Follow the [Web3Auth Unity SDK Setup Guide](https://web3auth.io/docs/sdk/pnp/unity/installation) for installation and configuration
   - Get your Client ID from [Web3Auth Dashboard](https://dashboard.web3auth.io)
   - Open the demo scene in `Assets/Scenes/Web3AuthDemo.unity`
   - Select the Web3Auth game object
   - Paste your Client ID in the inspector

## 📚 Example Implementation

The example code in this repository demonstrates:
- Basic Web3Auth initialization and setup
- Social login implementation
- User info retrieval
- Private key management
- Basic Ethereum blockchain interaction

Check out:
- `Assets/Scripts` directory for the implementation details
- [Web3Auth Unity Integration Guide](https://web3auth.io/docs/sdk/pnp/unity/initialize) for detailed configuration steps
- [Platform Setup Guide](https://web3auth.io/docs/sdk/pnp/unity/platform-setup) for iOS, Android, and WebGL configuration

## 🤝 Support

- [Documentation](https://web3auth.io/docs/sdk/pnp/unity)
- [Discord](https://discord.gg/web3auth)
- [Guides](https://web3auth.io/docs/guides)

## 📝 License

MIT License
