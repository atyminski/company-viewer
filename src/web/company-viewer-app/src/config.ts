const defaultSettings = {
    API_URL: 'http://localhost:5000'
  }
const settings = {...defaultSettings, ...process.env}
export default settings