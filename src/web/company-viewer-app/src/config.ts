const defaultSettings = {
    API_URL: 'http://localhost'
  }
const settings = {
  ...defaultSettings,
  API_URL: process.env.REACT_APP_API_URL
}
export default settings