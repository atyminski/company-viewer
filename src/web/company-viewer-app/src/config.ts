const defaultSettings = {
  REACT_APP_API_URL: 'http://localhost'
}
const settings = {
  ...defaultSettings,
  ...process.env
}
export default settings